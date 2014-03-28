/*################################################################################################*/
/* Script     : PRF_Data_PRF.sql                                                                  */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

connect PRF/PRF@MCDDEV
DELETE BM_PARAM;
Insert into BM_PARAM (CODE,VALEUR) values ('SECTION_COURANTE','AUTO');
Insert into BM_PARAM (CODE,VALEUR) values ('IMPORTATION_AUTORISE','TRUE');
commit;
disconnect
