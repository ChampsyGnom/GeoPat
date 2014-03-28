/*################################################################################################*/
/* Script     : INF_Function.sql                                                                  */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

create or replace
FUNCTION PR_TO_ABS
( Liaison IN VARCHAR2
, Sens IN VARCHAR2
, Pr IN VARCHAR2
) RETURN NUMBER AS
prNumStr  varchar(50);
prDpltStr varchar(50);
prSens varchar(10);
strTest varchar(50);
sqlQuery varchar(10000);
nbPrBefore  Number(10);
nbPr  Number(10);
nbPrAfter  Number(10);
userPrNum  Number(10);
searchPrNum  Number(10);
searchPrDplt  Number(10);
userPrDplt  Number(10);
bddPrNum  Number(10);
bddPrAbs  Number(10);
bddPrDplt  Number(10);
needExitLoop  Number(10);
countLoop  Number(10);
itemAbs  Number(10);
itemDplt  Number(10);
resultAbs Number(10);

BEGIN

   if (Pr is null) then
        return null;
    end if;

    if (Liaison is null) then
        return null;
    end if;

    if (Sens is null) then
        return null;
    end if;
  -- On vérifie que la liaison est renseigné
  if (LENGTH(Liaison) = 0) then
     return -1;
  end if;

  -- On vérifie que le sens est renseigné
  if (LENGTH(Sens) = 0) then
     return -1;
  end if;

  -- On vérifie que le PR est renseigné
  if (LENGTH(Pr) = 0) then
     return -1;
  end if;

  -- On vérifie que le PR ne contient que des chiffres des esapces et des plus
  strTest := Pr;
  strTest := REPLACE(strTest,'+','');
  strTest := REPLACE(strTest,' ','');
  strTest := REPLACE(strTest,'0','');
  strTest := REPLACE(strTest,'1','');
  strTest := REPLACE(strTest,'2','');
  strTest := REPLACE(strTest,'3','');
  strTest := REPLACE(strTest,'4','');
  strTest := REPLACE(strTest,'5','');
  strTest := REPLACE(strTest,'6','');
  strTest := REPLACE(strTest,'7','');
  strTest := REPLACE(strTest,'8','');
  strTest := REPLACE(strTest,'9','');
  if (LENGTH(strTest) > 0) then
     return -1;
  end if;


  prSens := Sens;
  if (prSens <> '1' and prSens <> '2') then
       prSens := '1';

    dbms_output.put_line('changement sens '||prNumStr);

  end if;






  if (INSTR(Pr,'+') = 0) then
    return TO_NUMBER(Pr);
  else
    prNumStr := SUBSTR(Pr,0,INSTR(Pr,'+'));
    prDpltStr := SUBSTR(Pr,INSTR(Pr,'+'));
  end if;
  prNumStr := REPLACE(prNumStr,'+','');
  prDpltStr := REPLACE(prDpltStr,'+','');
  prNumStr := REPLACE(prNumStr,' ','');
  prDpltStr := REPLACE(prDpltStr,' ','');

  -- On vérifie que l'on as pas plusieurs + ou plusieurs espaces
  strTest := prNumStr;
  strTest := REPLACE(strTest,'0','');
  strTest := REPLACE(strTest,'1','');
  strTest := REPLACE(strTest,'2','');
  strTest := REPLACE(strTest,'3','');
  strTest := REPLACE(strTest,'4','');
  strTest := REPLACE(strTest,'5','');
  strTest := REPLACE(strTest,'6','');
  strTest := REPLACE(strTest,'7','');
  strTest := REPLACE(strTest,'8','');
  strTest := REPLACE(strTest,'9','');
  if (LENGTH(strTest) > 0) then
     return -1;
  end if;

  -- On vérifie que l'on as pas plusieurs + ou plusieurs espaces
  strTest := prDpltStr;
  strTest := REPLACE(strTest,'0','');
  strTest := REPLACE(strTest,'1','');
  strTest := REPLACE(strTest,'2','');
  strTest := REPLACE(strTest,'3','');
  strTest := REPLACE(strTest,'4','');
  strTest := REPLACE(strTest,'5','');
  strTest := REPLACE(strTest,'6','');
  strTest := REPLACE(strTest,'7','');
  strTest := REPLACE(strTest,'8','');
  strTest := REPLACE(strTest,'9','');
  if (LENGTH(strTest) > 0) then
     return -1;
  end if;

  userPrNum := TO_NUMBER(prNumStr);
  userPrDplt := TO_NUMBER(prDpltStr);

  dbms_output.put_line('PR N° : '||prNumStr);
  dbms_output.put_line('PR Dplt : '||prDpltStr);

  sqlQuery := 'SELECT COUNT(*) FROM REPERE_INF WHERE LIAISON_INF__LIAISON='''||  liaison  ||''' AND CHAUSSEE_INF__SENS='''|| prSens ||'''';
  execute immediate sqlQuery into nbPr;
  if (nbPr = 0) then
   dbms_output.put_line('Cas du PR sans repérage : '||prSens);
    return  (userPrNum * 1000) + userPrDplt;
  end if;

  sqlQuery := 'SELECT COUNT(*) FROM REPERE_INF WHERE LIAISON_INF__LIAISON='''||  liaison  ||''' AND CHAUSSEE_INF__SENS='''|| prSens ||''' AND NUM<='||prNumStr;
  execute immediate sqlQuery into nbPrBefore;
  if (nbPrBefore  = 0) then
    dbms_output.put_line('Cas du PR avant le repérage');
    sqlQuery := 'SELECT NUM,INTER,ABS_CUM  FROM REPERE_INF WHERE LIAISON_INF__LIAISON='''||  liaison  ||''' AND CHAUSSEE_INF__SENS='''|| prSens ||''' AND ROWNUM<=1 ORDER BY NUM';
    execute immediate sqlQuery into bddPrNum,bddPrDplt,bddPrAbs;

    return bddPrAbs - ((bddPrNum-userPrNum) * 1000) + userPrDplt;
  end if;

  sqlQuery := 'SELECT COUNT(*) FROM REPERE_INF WHERE LIAISON_INF__LIAISON='''||  liaison  ||''' AND CHAUSSEE_INF__SENS='''|| prSens ||''' AND NUM>='||prNumStr;
  execute immediate sqlQuery into nbPrAfter;
  if (nbPrAfter  = 0) then
    -- Cas du PR après le repérage

     sqlQuery := 'SELECT NUM,INTER,ABS_CUM FROM REPERE_INF WHERE LIAISON_INF__LIAISON='''||  liaison  ||''' AND CHAUSSEE_INF__SENS='''|| prSens ||''' AND ROWNUM<=1 ORDER BY NUM DESC';
       dbms_output.put_line('Cas du PR apres le repérage : '||sqlQuery);
     execute immediate sqlQuery into bddPrNum,bddPrDplt,bddPrAbs;

     return   (( userPrNum - bddPrNum)  * 1000)+ bddPrAbs + userPrDplt;
  end if;

    if (nbPrAfter = 0 and nbPrBefore = 0) then
       return (userPrNum*1000) + userPrDplt;
    end if;

  countLoop  := 0;
  needExitLoop := 0;
  searchPrNum := userPrNum;
  searchPrDplt := userPrDplt;
  resultAbs := -1;
  WHILE needExitLoop = 0 LOOP
    sqlQuery := 'SELECT COUNT(*) FROM REPERE_INF WHERE LIAISON_INF__LIAISON='''||  liaison  ||''' AND CHAUSSEE_INF__SENS='''|| prSens ||''' AND ROWNUM<=1 AND NUM>='||searchPrNum ||' ORDER BY NUM';
    execute immediate sqlQuery into nbPrAfter;
    if (nbPrAfter > 0) then
        sqlQuery := 'SELECT ABS_CUM,INTER FROM REPERE_INF WHERE LIAISON_INF__LIAISON='''||  liaison  ||''' AND CHAUSSEE_INF__SENS='''|| prSens ||''' AND ROWNUM<=1 AND NUM>='||searchPrNum ||' ORDER BY NUM';
        execute immediate sqlQuery into itemAbs,itemDplt;
        if (searchPrDplt >itemDplt) then
             dbms_output.put_line('Inter saisi > inter repere ');
            searchPrDplt := searchPrDplt - itemDplt;
            searchPrNum := searchPrNum + 1;
        else
            dbms_output.put_line('Inter saisi <  inter repere ');
            resultAbs := itemAbs +  searchPrDplt;
            needExitLoop := 1;
        end if;
    else
        resultAbs := itemAbs +  searchPrDplt;
        needExitLoop := 1;
    end if;


    countLoop := countLoop + 1;
    if (countLoop >= 10000) then
        needExitLoop := 1;
    end if;
  END LOOP;


  if (countLoop >= 10000) then
    return -1;
  else
    return resultAbs;
  end if;

END PR_TO_ABS;

/

create or replace
FUNCTION ABS_TO_PR
( Liaison IN VARCHAR2
, Sens IN VARCHAR2
, Abs IN NUMBER
) RETURN VARCHAR2 AS
sqlQuery varchar(10000);
sqlCount NUMBER;
sqlValid Number;
prNum Number;
prAbsCum Number;
bddMaxAbsCum Number;
bddMinAbsCum Number;
bddMinPr Number;
bddMaxPr Number;
deltaPr Number;
deltaAbs  Number;
prDplt NUMBER;
prCount Number;
prSens varchar(10);
BEGIN
    if (Abs is null) then
        return null;
    end if;

    if (Liaison is null) then
        return null;
    end if;

    if (Sens is null) then
        return null;
    end if;
    prSens := Sens;
    if (prSens = '3') then
        prSens := '1';
    end if;
    sqlValid := 0;
    sqlQuery:= 'SELECT Count(*) FROM INF.REPERE_INF WHERE ABS_CUM<='||TO_CHAR(Abs)||' AND '||TO_CHAR(Abs)||'< (ABS_CUM+INTER) AND LIAISON_INF__LIAISON='''|| liaison ||''' AND CHAUSSEE_INF__SENS='''|| prSens||'''';
    execute immediate sqlQuery into sqlCount;
    if (sqlCount = 1) then
        sqlValid := 1;
        sqlQuery:= 'SELECT NUM,ABS_CUM FROM INF.REPERE_INF WHERE ABS_CUM<='||TO_CHAR(Abs)||' AND '||TO_CHAR(Abs)||'< (ABS_CUM+INTER) AND LIAISON_INF__LIAISON='''|| liaison ||''' AND CHAUSSEE_INF__SENS='''|| prSens||'''';

    else
        sqlQuery:= 'SELECT Count(*) FROM INF.REPERE_INF WHERE ABS_CUM<='||TO_CHAR(Abs)||' AND '||TO_CHAR(Abs)||'< (ABS_CUM+INTER) AND LIAISON_INF__LIAISON='''|| liaison ||''' AND CHAUSSEE_INF__SENS=''1''';
        execute immediate sqlQuery into sqlCount;
        if (sqlCount = 1) then
            sqlValid := 1;
            sqlQuery:= 'SELECT NUM,ABS_CUM FROM INF.REPERE_INF WHERE ABS_CUM<='||TO_CHAR(Abs)||' AND '||TO_CHAR(Abs)||'< (ABS_CUM+INTER) AND LIAISON_INF__LIAISON='''|| liaison ||''' AND CHAUSSEE_INF__SENS=''1''';
        end if;
    end if;
    if (sqlValid  = 1) then
        execute immediate sqlQuery into prNum,prAbsCum;
        prDplt := abs-prAbsCum;
        return TO_CHAR(prNum)||' +'||REPLACE(TO_CHAR(prDplt,'0000'),' ','');
    else
    
        sqlQuery:= 'SELECT  COUNT(*) FROM INF.REPERE_INF WHERE LIAISON_INF__LIAISON='''|| liaison ||''' AND CHAUSSEE_INF__SENS='''|| prSens||'''';
        execute immediate sqlQuery into prCount;
          
        if (prCount = 0) then
            dbms_output.put_line('Aucun pr ');
            prNum := floor((Abs) / 1000) ;
            prDplt := (Abs - ((prNum) * 1000));
            return TO_CHAR(prNum)||' +'||REPLACE(TO_CHAR(prDplt,'0000'),' ','');
            
        else
           if (Abs < bddMinAbsCum) then
                dbms_output.put_line('Inférieur au répérage min ');
                deltaAbs :=  bddMinAbsCum - Abs;
                sqlQuery:= 'SELECT NUM FROM INF.REPERE_INF WHERE LIAISON_INF__LIAISON='''|| liaison ||''' AND CHAUSSEE_INF__SENS='''|| prSens||''' AND ABS_CUM='|| bddMinAbsCum;
                execute immediate sqlQuery into bddMinPr;
                deltaPr := (Round(deltaAbs / 1000));
                prNum :=  bddMinPr - deltaPr;
                prDplt :=Abs-( bddMinAbsCum - (deltaPr *1000));
                dbms_output.put_line('prNum  '|| prNum);
                dbms_output.put_line('prDplt  '|| prDplt);
                return TO_CHAR(prNum)||' +'||REPLACE(TO_CHAR(prDplt,'0000'),' ','');
          
            else
                 dbms_output.put_line('supérieur au répérage max ');
                 sqlQuery:= 'SELECT MAX(ABS_CUM) FROM INF.REPERE_INF WHERE LIAISON_INF__LIAISON='''|| liaison ||''' AND CHAUSSEE_INF__SENS='''|| prSens||'''';
            
                 execute immediate sqlQuery into bddMaxAbsCum;
                 deltaAbs := Abs-  bddMaxAbsCum ;
                 sqlQuery:= 'SELECT NUM FROM INF.REPERE_INF WHERE LIAISON_INF__LIAISON='''|| liaison ||''' AND CHAUSSEE_INF__SENS='''|| prSens||''' AND ABS_CUM='|| bddMaxAbsCum||' and ROWNUM = 1';                 
                 execute immediate sqlQuery into bddMaxPr;
                 deltaPr := (Round(deltaAbs / 1000));
                 prNum :=  bddMaxPr + deltaPr;
                 prDplt :=Abs-( bddMaxAbsCum + (deltaPr *1000));
                 return TO_CHAR(prNum)||' +'||REPLACE(TO_CHAR(prDplt,'0000'),' ','');
            
            end if;
        end if;
    end if;

END ABS_TO_PR;

/

create or replace
FUNCTION ABS_TO_WGS

(
   PARAM_LAYER_NAME IN VARCHAR2
, PARAM_LIAISON IN VARCHAR2
, PARAM_SENS IN VARCHAR2
, PARAM_ABS IN NUMBER

)

RETURN VARCHAR2 AS
v_counter number;
v_x1 number;
v_y1 number;
v_x2 number;
v_y2 number;
v_abs_deb number;
v_abs_fin number;
v_delta_abs number;
v_coeff_abs number;
v_delta_x number;
v_delta_y number;
v_x_result number;
v_y_result number;
BEGIN
    select count(*) into v_counter  from WGS_INF TBL_WGS
    where TBL_WGS.LIAISON=PARAM_LIAISON and TBL_WGS.SENS = PARAM_SENS AND PARAM_ABS>=TBL_WGS.ABS_DEB AND PARAM_ABS<TBL_WGS.ABS_FIN AND TBL_WGS.layer_name=PARAM_LAYER_NAME  ;

    if (v_counter = 0) then
        return null;
    else
        if (v_counter = 1) then
            select  TBL_WGS.X1,TBL_WGS.Y1,TBL_WGS.X2,TBL_WGS.Y2,TBL_WGS.ABS_DEB,TBL_WGS.ABS_FIN
            into v_x1,v_y1,v_x2,v_y2,v_abs_deb,v_abs_fin
            from WGS_INF TBL_WGS
            where TBL_WGS.LIAISON=PARAM_LIAISON and TBL_WGS.SENS = PARAM_SENS AND PARAM_ABS>=TBL_WGS.ABS_DEB AND PARAM_ABS<TBL_WGS.ABS_FIN AND TBL_WGS.layer_name=PARAM_LAYER_NAME  ;

            v_delta_abs := abs(PARAM_ABS - v_abs_deb);
            v_coeff_abs := v_delta_abs / (v_abs_fin-v_abs_deb);
            v_delta_x := abs( v_x2 - v_x1);
            v_delta_y := abs( v_y2 - v_y1);
            if (v_x2 > v_x1) then
                 v_x_result := v_x1 + (v_delta_x * v_coeff_abs);
            else
                 v_x_result := v_x1 - (v_delta_x * v_coeff_abs);
            end if;

            if (v_y2 > v_y1) then
                 v_y_result := v_y1 + (v_delta_y * v_coeff_abs);
            else
                 v_y_result := v_y1 - (v_delta_y * v_coeff_abs);
            end if;
            return replace( to_char( v_x_result),',','.')||','||replace(to_char(v_y_result),',','.');
        else
            return null;
        end if;
    end if;




END ABS_TO_WGS;

/

create or replace FUNCTION WGS_TO_NUM_OUVRAGES
( PARAM_LAYER_NAME IN VARCHAR2
, PARAM_METIER IN VARCHAR2
, PARAM_CENTER_X IN NUMBER
, PARAM_CENTER_Y IN NUMBER
, PARAM_BOX_SIZE IN NUMBER
) RETURN VARCHAR2 AS
TYPE ref_cursor IS REF CURSOR;
cur REF_CURSOR;
v_top number;
v_left number;
v_bottom number;
v_right number;
v_deg_to_metter number;
v_wgs varchar(500);
v_num varchar(500);
v_sql varchar(10000);
v_wgs_x number;
v_wgs_y number;
v_result  varchar(10000);
BEGIN
    v_deg_to_metter := 111319;
    v_result := '';
    v_top :=  PARAM_CENTER_Y - (PARAM_BOX_SIZE / v_deg_to_metter);
    v_left :=  PARAM_CENTER_X - (PARAM_BOX_SIZE / v_deg_to_metter);
    v_bottom :=  PARAM_CENTER_Y + (PARAM_BOX_SIZE / v_deg_to_metter);
    v_right :=  PARAM_CENTER_X + (PARAM_BOX_SIZE / v_deg_to_metter);
    
    v_sql :=  'SELECT INF.ABS_TO_WGS('''||PARAM_LAYER_NAME||''',LIAISON,SENS,ABS_DEB), NUM_'||PARAM_METIER||' FROM '||PARAM_METIER||'.DSC_'||PARAM_METIER;
   dbms_output.put_line('TOP : '||v_top);
   dbms_output.put_line('LEFT : '||v_left);
   dbms_output.put_line('BOTTOM : '||v_bottom);
   dbms_output.put_line('RIGHT : '||v_right);
    OPEN cur FOR v_sql;
      LOOP
        FETCH cur INTO v_wgs,v_num;
        EXIT WHEN cur%NOTFOUND;
        if (v_wgs = null) then
             null;
        else
            v_wgs_x :=TO_NUMBER( REPLACE( REPLACE( SUBSTR(v_wgs,0,INSTR(v_wgs,',')),' ',''),',',''));
            v_wgs_y :=TO_NUMBER( REPLACE( REPLACE( SUBSTR(v_wgs,INSTR(v_wgs,',')),' ',''),',',''));
            if (v_wgs_x >= v_left and v_wgs_x<=v_right and v_wgs_y>=v_top and v_wgs_y<=v_bottom) then
                v_result := v_result ||v_num||';';
            end if;
           --dbms_output.put_line(v_wgs_x);
        end if;
      --  dbms_output.put_line( v_wgs||' : ' ||v_num );
      END LOOP;
    
      CLOSE cur;
      if (LENGTH(v_result) > 0) then
        v_result:= SUBSTR(v_result,0,LENGTH(v_result)-1);
        return v_result;
      end if;
  RETURN NULL;
  
END WGS_TO_NUM_OUVRAGES;

/

create or replace
FUNCTION ABS_TO_WGS_LINE

(
   PARAM_LAYER_NAME IN VARCHAR2
, PARAM_LIAISON IN VARCHAR2
, PARAM_SENS IN VARCHAR2
, PARAM_ABS_DEB IN NUMBER
, PARAM_ABS_FIN IN NUMBER
)

RETURN clob IS
v_line clob;
v_start_point varchar(10000);
v_end_point varchar(10000);
v_counter number;
v_x1 number;
v_y1 number;
v_x2 number;
v_y2 number;
v_abs_deb number;
v_abs_fin number;
v_delta_abs number;
v_coeff_abs number;
v_delta_x number;
v_delta_y number;
v_x_result number;
v_y_result number;
v_line_index  number;

  v_wgs  WGS_INF%rowtype;
  CURSOR c_wgs IS
  SELECT  TBL_WGS.X1,TBL_WGS.Y1,TBL_WGS.X2,TBL_WGS.Y2,TBL_WGS.ABS_DEB,TBL_WGS.ABS_FIN,TBL_WGS.line_index
  FROM WGS_INF TBL_WGS  where TBL_WGS.LIAISON=PARAM_LIAISON and TBL_WGS.SENS = PARAM_SENS
  AND TBL_WGS.ABS_FIN > PARAM_ABS_DEB
  AND  TBL_WGS.ABS_DEB < PARAM_ABS_FIN
  AND TBL_WGS.layer_name=PARAM_LAYER_NAME ORDER BY  TBL_WGS.ABS_DEB ;

BEGIN

    select count(*) into v_counter  from WGS_INF TBL_WGS
    where TBL_WGS.LIAISON=PARAM_LIAISON and TBL_WGS.SENS = PARAM_SENS AND   PARAM_ABS_DEB <  TBL_WGS.ABS_FIN AND  PARAM_ABS_FIN > TBL_WGS.abs_deb AND TBL_WGS.layer_name=PARAM_LAYER_NAME  ;

    if (v_counter = 0) then
        return null;
    else

        v_line := '';

        select  TBL_WGS.X1,TBL_WGS.Y1,TBL_WGS.X2,TBL_WGS.Y2,TBL_WGS.ABS_DEB,TBL_WGS.ABS_FIN,TBL_WGS.LINE_INDEX
        into v_x1,v_y1,v_x2,v_y2,v_abs_deb,v_abs_fin,v_line_index
        from WGS_INF TBL_WGS
        where TBL_WGS.LIAISON=PARAM_LIAISON and TBL_WGS.SENS = PARAM_SENS AND TBL_WGS.ABS_DEB >=PARAM_ABS_DEB AND TBL_WGS.layer_name=PARAM_LAYER_NAME AND ROWNUM=1 ORDER BY TBL_WGS.ABS_DEB ;

        v_delta_abs := abs(PARAM_ABS_DEB - v_abs_deb);
        v_coeff_abs := v_delta_abs / (v_abs_fin-v_abs_deb);
        v_delta_x := abs( v_x2 - v_x1);
        v_delta_y := abs( v_y2 - v_y1);
        if (v_x2 > v_x1) then
             v_x_result := v_x1 + (v_delta_x * v_coeff_abs);
        else
             v_x_result := v_x1 - (v_delta_x * v_coeff_abs);
        end if;

        if (v_y2 > v_y1) then
             v_y_result := v_y1 + (v_delta_y * v_coeff_abs);
        else
             v_y_result := v_y1 - (v_delta_y * v_coeff_abs);
        end if;
        v_line := v_line ||  replace( to_char( v_x_result),',','.')||','||replace(to_char(v_y_result),',','.')||','|| to_char(v_line_index) || '|';





       FOR v_wgs in c_wgs
       LOOP
            v_line := v_line ||  replace( to_char( v_wgs.X1),',','.')||','||replace(to_char(v_wgs.Y1),',','.')||','|| to_char(v_wgs.LINE_INDEX)   || '|';
            v_line := v_line ||  replace( to_char( v_wgs.X2),',','.')||','||replace(to_char(v_wgs.Y2),',','.')||','|| to_char(v_wgs.LINE_INDEX)   || '|';
       END LOOP;



        select  TBL_WGS.X1,TBL_WGS.Y1,TBL_WGS.X2,TBL_WGS.Y2,TBL_WGS.ABS_DEB,TBL_WGS.ABS_FIN,TBL_WGS.LINE_INDEX
        into v_x1,v_y1,v_x2,v_y2,v_abs_deb,v_abs_fin,v_line_index
        from WGS_INF TBL_WGS
        where TBL_WGS.LIAISON=PARAM_LIAISON and TBL_WGS.SENS = PARAM_SENS AND TBL_WGS.ABS_FIN <  PARAM_ABS_FIN AND TBL_WGS.layer_name=PARAM_LAYER_NAME AND ROWNUM=1 ORDER BY TBL_WGS.ABS_FIN DESC;

        v_delta_abs := abs(PARAM_ABS_FIN - v_abs_deb);
        v_coeff_abs := v_delta_abs / (v_abs_fin-v_abs_deb);
        v_delta_x := abs( v_x2 - v_x1);
        v_delta_y := abs( v_y2 - v_y1);
        if (v_x2 > v_x1) then
             v_x_result := v_x1 + (v_delta_x * v_coeff_abs);
        else
             v_x_result := v_x1 - (v_delta_x * v_coeff_abs);
        end if;

        if (v_y2 > v_y1) then
             v_y_result := v_y1 + (v_delta_y * v_coeff_abs);
        else
             v_y_result := v_y1 - (v_delta_y * v_coeff_abs);
        end if;
         v_line := v_line ||  replace( to_char( v_x_result),',','.')||','||replace(to_char(v_y_result),',','.')||','||to_char( v_line_index ) ;


        return v_line;
    end if;




END ABS_TO_WGS_LINE;

/

create or replace
FUNCTION GET_DECOUPAGE
( Liaison IN VARCHAR2
, Sens IN VARCHAR2
, AbsDeb IN VARCHAR2
, AbsFin IN VARCHAR2
, FamDec IN VARCHAR2
) RETURN VARCHAR2 AS
sqlQuery varchar(10000);
sqlCount NUMBER;
libelle  varchar(500);
BEGIN
  if (Liaison is null) then
        return null;
  end if;

  if (Sens is null) then
        return null;
  end if;

  if (AbsDeb is null) then
        return null;
  end if;

  if (FamDec is null) then
        return null;
  end if;
    
  if (AbsFin is Null) then
  
  BEGIN
     sqlQuery := 'SELECT CD_DEC_INF.LIBELLE FROM TR_DEC_INF,CD_DEC_INF WHERE TR_DEC_INF.LIAISON_INF__LIAISON='''||Liaison||''' AND (TR_DEC_INF.CHAUSSEE_INF__SENS='''||SENS||''' OR TR_DEC_INF.CHAUSSEE_INF__SENS=''3'') AND '||AbsDeb||'>=TR_DEC_INF.ABS_DEB AND '||AbsDeb||'<TR_DEC_INF.ABS_FIN AND TR_DEC_INF.FAM_DEC_INF__FAM_DEC='''||FamDec||''' AND TR_DEC_INF.CD_DEC_INF__CD_DEC=CD_DEC_INF.CD_DEC AND ROWNUM=1  AND TR_DEC_INF.FAM_DEC_INF__FAM_DEC=CD_DEC_INF.FAM_DEC_INF__FAM_DEC' ;
     execute immediate sqlQuery into libelle;
     return libelle;
  EXCEPTION
     WHEN OTHERS THEN
      return NULL;
  END;
  else
     BEGIN
   sqlQuery := 'SELECT CD_DEC_INF.LIBELLE FROM TR_DEC_INF,CD_DEC_INF WHERE TR_DEC_INF.LIAISON_INF__LIAISON='''||Liaison||''' AND (TR_DEC_INF.CHAUSSEE_INF__SENS='''||SENS||''' OR TR_DEC_INF.CHAUSSEE_INF__SENS=''3'') AND '||AbsFin||'>TR_DEC_INF.ABS_DEB AND '||AbsDeb||'<TR_DEC_INF.ABS_FIN AND TR_DEC_INF.FAM_DEC_INF__FAM_DEC='''||FamDec||''' AND TR_DEC_INF.CD_DEC_INF__CD_DEC=CD_DEC_INF.CD_DEC AND ROWNUM=1  AND TR_DEC_INF.FAM_DEC_INF__FAM_DEC=CD_DEC_INF.FAM_DEC_INF__FAM_DEC';
     execute immediate sqlQuery into libelle;
     return libelle;
      EXCEPTION
     WHEN OTHERS THEN
      return NULL;
      END;
    
  end if;

END GET_DECOUPAGE;

/

create or replace
FUNCTION WGS_DISTANCE (
  Lat1 NUMBER,
  Lon1 NUMBER,
  Lat2 NUMBER,
  Lon2 NUMBER) return NUMBER as 

e NUMBER;
f NUMBER;
g NUMBER;
h NUMBER;
i NUMBER;
j NUMBER;
k NUMBER;
v_Return NUMBER;
    
BEGIN

    
    e := 3.14159265358979 * Lat1 / 180;
    f := 3.14159265358979 * Lon1 / 180;
    g := 3.14159265358979 * Lat2 / 180;
    h := 3.14159265358979 * Lon2 / 180;
    
    
    i := COS(e) * COS(g) * COS(f) * COS(h) + COS(e) * SIN(f) * COS(g) * SIN(h) + SIN(e) * SIN(g);
    
    j := ACOS(i);
	
    v_return := 6371 * j;
    
    dbms_output.put_line(e);
    dbms_output.put_line(f);
    dbms_output.put_line(g);
    dbms_output.put_line(h);
    dbms_output.put_line(i);
    dbms_output.put_line(j);
    dbms_output.put_line(k);
    
    return v_return;
END WGS_DISTANCE;

/

create or replace FUNCTION ST_ASGEOJSON
( layerName IN VARCHAR2 default null
, liaison IN VARCHAR2 default null
, sens IN VARCHAR2 default null
, absDeb IN NUMBER default null
, absFin IN NUMBER default null
, voie IN VARCHAR2 default null
) 


RETURN CLOB AS
sqlQuery varchar(10000);
sqlCounter number;
refDeb number;
refFin number;
refX1  number;
refY1 number;
refX2  number;
refY2  number;
refDelta number;
objDelta number;
refDeltaX number;
refDeltaY  number;
coeff number;
objX number;
objY  number;
coordIndex number;
nbPoint  number;
liAddCoordCount number;
liAddLineCount number;
segmentLength number;
dataLength number;
ptX number;
ptY number;
resultJson CLOB;
TYPE WgsCoord IS VARRAY(2) OF Number;
TYPE WgsLine IS TABLE OF WgsCoord;
TYPE WgsMultiLine IS TABLE OF WgsLine;
WgsMultiLineInfo WgsMultiLine;
WgsLineInfo WgsLine;
lineIndexCount number;
WgsCoordInfo WgsCoord;
liIndex  number;
lsLineIndex varchar(10);
   v_wgs  WGS_INF%rowtype;
  CURSOR c_wgs IS
  SELECT  DISTINCT LINE_INDEX FROM  INF.WGS_INF WHERE LAYER_NAME=layerName AND LIAISON= liaison AND SENS= sens AND absdeb <ABS_FIN AND absfin > ABS_DEB ORDER BY LINE_INDEX ;
  
   v_wgs_coord  WGS_INF%rowtype;
  CURSOR c_wgs_coord(lineIndex  number) IS
  SELECT ABS_DEB,ABS_FIN,X1,Y1,X2,Y2 FROM INF.WGS_INF WHERE LAYER_NAME=layerName AND LIAISON= liaison AND SENS= sens AND absdeb <ABS_FIN AND absfin > ABS_DEB AND LINE_INDEX=lineIndex ORDER BY ABS_DEB;
  
  


BEGIN


   if (layerName is null) then RETURN null;
   end if;
   
   if (liaison is null) then RETURN null;
   end if;
   
   if (sens is null) then RETURN null;
   end if;
   
   if (absDeb is null) then RETURN null;
   end if;
   
   if (absFin is null) then
        select count(*) into sqlCounter  FROM INF.WGS_INF WHERE LAYER_NAME = layername AND LIAISON=liaison  AND SENS= sens  AND  absdeb>=ABS_DEB AND absdeb < ABS_FIN ;
        if (sqlCounter >0) then
              select ABS_DEB,ABS_FIN,X1,Y1,X2,Y2  into refDeb, reffin, refx1, refy1, refx2, refy2  FROM INF.WGS_INF WHERE LAYER_NAME = layername AND LIAISON=liaison  AND SENS= sens  AND  absdeb>=ABS_DEB AND absdeb < ABS_FIN AND ROWNUM=1;
             
                refDelta := refFin - refDeb;
                objDelta := absDeb - refDeb;
                refDeltaX := refX2 - refX1;
                refDeltaY := refY2 - refY1;
                coeff := 0;
                if (objDelta > 0) then                
                   coeff := objDelta / refDelta;
                end if;
                objX := refX1 + (refDeltaX * coeff);
                objY := refY1 + (refDeltaY * coeff);
                resultJson := '{"type":"Point","coordinates":['||objX||','||objY||']}';
                
                RETURN resultJson;
        else
              RETURN NULL;
        end if;
        
   else
      
        if (voie is null) then
            WgsMultiLineInfo := WgsMultiLine();
             SELECT COUNT(*) into nbPoint FROM INF.WGS_INF  WHERE LAYER_NAME= layername AND LIAISON= liaison AND SENS= sens AND absdeb < ABS_FIN AND absfin > ABS_DEB;
            lineIndexCount := 0;
             FOR v_wgs in c_wgs
             LOOP
             WgsLineInfo := WgsLine();
             lineIndexCount := lineIndexCount +1;
             WgsMultiLineInfo.extend(1);
             
                coordIndex := 0;
                 FOR v_wgs_coord in c_wgs_coord(v_wgs.LINE_INDEX)         LOOP
                 refX1 :=v_wgs_coord.X1;
		 refY1 :=v_wgs_coord.Y1;
		 refX2 :=v_wgs_coord.X2;
		 refY2 :=v_wgs_coord.Y2;
		 refDeb :=v_wgs_coord.ABS_DEB;
		 refFin :=v_wgs_coord.ABS_FIN;
                 
                
                 -- Le segement est entierement dans l'intervale on le prend entier
                 if (absdeb <= refDeb and absFin >= refFin) then
                    WgsLineInfo.EXTEND(1);   
                    coordIndex := coordIndex +1;
                    WgsLineInfo(coordIndex) := WgsCoord(refX1,refY1);
                   
                    
                    WgsLineInfo.EXTEND(1);   
                    coordIndex := coordIndex +1;
                    WgsLineInfo(coordIndex) := WgsCoord(refX2,refY2);
                    
                    null;
                 end if;
                 
                 
                --  Le debut de la data commence après le début du segment on prend que la fin du segmenet
                 if (absDeb > refDeb and absFin >= refFin) then
                    segmentLength := refFin - refDeb;
                    dataLength := absDeb - refDeb;
                    coeff := dataLength / segmentLength;
                    refDeltaX := refX2 - refX1;
                    refDeltaY := refY2 - refY1;
                    ptX := refX1 + (refDeltaX * coeff);
                    ptY := refY1 + (refDeltaY * coeff);
                    
                    WgsLineInfo.EXTEND(1);   
                    coordIndex := coordIndex +1;
                    WgsLineInfo(coordIndex) := WgsCoord(ptX,ptY);
                    
                    
                    WgsLineInfo.EXTEND(1);   
                    coordIndex := coordIndex +1;
                    WgsLineInfo(coordIndex) := WgsCoord(refX2,refY2);
                    

                    null;
                 end if;
                 
                 
                
                -- Le début de la data finit avant la fin du segment , on ne prend que le début du segment
                 if (absDeb <= refDeb and absFin< refFin) then
                    segmentLength := refFin - refDeb;
                    dataLength := absFin - refDeb;
                    coeff := dataLength / segmentLength;
                    refDeltaX := refX2 - refX1;
                    refDeltaY := refY2 - refY1;
                    ptX := refX1 + (refDeltaX * coeff);
                    ptY := refY1 + (refDeltaY * coeff);
                    
                    WgsLineInfo.EXTEND(1);   
                    coordIndex := coordIndex +1;
                    WgsLineInfo(coordIndex) := WgsCoord(refX1,refY1);
                    
                    
                    WgsLineInfo.EXTEND(1);   
                    coordIndex := coordIndex +1;
                    WgsLineInfo(coordIndex) := WgsCoord(ptX,ptY);
                   
                 end if;
                    
                end loop;
           
                 WgsMultiLineInfo(lineIndexCount) := WgsLineInfo;
            END LOOP;
            if (WgsMultiLineInfo.COUNT = 0) then
                return null;
            end if;
            
            if (WgsMultiLineInfo.COUNT = 1) then
                WgsLineInfo := WgsMultiLineInfo(1);
                resultJson := '{"type":"LineString","coordinates":[';
                liAddCoordCount := 0;
                FOR i IN WgsLineInfo.FIRST..WgsLineInfo.LAST LOOP
                    WgsCoordInfo := WgsLineInfo(i);
                    if (liAddCoordCount = 0) then                    
                    resultJson :=  resultJson || '['|| TO_CHAR(WgsCoordInfo(1))||','||TO_CHAR(WgsCoordInfo(2))||']';
                    else
                    resultJson :=  resultJson || ',['||TO_CHAR(WgsCoordInfo(1))||','||TO_CHAR(WgsCoordInfo(2))||']';
                    end if ;                   
                    liAddCoordCount := liAddCoordCount + 1;
                END LOOP;
                 resultJson :=  resultJson || ']}';               
                 return resultJson;
              
                null;
            end if;
            
            if (WgsMultiLineInfo.COUNT > 1) then
                liaddlinecount := 0;
                resultJson := '{"type":"MultiLineString","coordinates":[';
                FOR i IN WgsMultiLineInfo.FIRST..WgsMultiLineInfo.LAST LOOP
                     if (liaddlinecount = 0) then
                           resultJson :=  resultJson || '[';
                       else
                           resultJson :=  resultJson || ',[';
                    end if;
                  
                    liAddCoordCount := 0;
                    WgsLineInfo := WgsMultiLineInfo(i);
                     FOR j IN WgsLineInfo.FIRST..WgsLineInfo.LAST LOOP
                         WgsCoordInfo := WgsLineInfo(j);
                        if (liAddCoordCount = 0) then
                            resultJson :=  resultJson || '['||TO_CHAR(WgsCoordInfo(1))||','||TO_CHAR(WgsCoordInfo(2))||']';
                        else                        
                            resultJson :=  resultJson || ',[' ||TO_CHAR(WgsCoordInfo(1))||','||TO_CHAR(WgsCoordInfo(2))||']';
                        end if ;                   
                        liAddCoordCount := liAddCoordCount + 1;
                    END LOOP;
                   
                     if (liaddlinecount = 0) then
                           resultJson :=  resultJson || ']';
                       else
                           resultJson :=  resultJson || ']';
                    end if;
                    liaddlinecount := liaddlinecount +1;
                END LOOP;
                 resultJson :=  resultJson || ']}';
                 return resultJson;
                null;
            end if;
        else
            dbms_output.put_line('Type polygon');
        end if;
   end if;
  RETURN NULL;
END ST_ASGEOJSON;
/

