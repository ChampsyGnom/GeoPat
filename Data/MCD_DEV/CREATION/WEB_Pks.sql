/*################################################################################################*/
/* Script     : WEB_Pks.sql                                                                       */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

ALTER TABLE NODE_WEB
ADD CONSTRAINT NODE_WEB_PK
PRIMARY KEY (ID) 
USING INDEX
;

ALTER TABLE CD_NODE_WEB
ADD CONSTRAINT CD_NODE_WEB_PK
PRIMARY KEY (NAME) 
USING INDEX
;

ALTER TABLE NODE_PARAM_WEB
ADD CONSTRAINT NODE_PARAM_WEB_PK
PRIMARY KEY (NODE_WEB__ID,CODE) 
USING INDEX
;

ALTER TABLE SYS_USER_WEB
ADD CONSTRAINT SYS_USER_WEB_PK
PRIMARY KEY (CODE_DBS,CODE_TABLE,CODE_COLONNE,NOM_USER,CODE_PRP) 
USING INDEX
;

ALTER TABLE STYLE_WEB
ADD CONSTRAINT STYLE_WEB_PK
PRIMARY KEY (ID) 
USING INDEX
;

ALTER TABLE STYLE_RULE_WEB
ADD CONSTRAINT STYLE_RULE_WEB_PK
PRIMARY KEY (ID) 
USING INDEX
;

ALTER TABLE MODELE_WEB
ADD CONSTRAINT MODELE_WEB_PK
PRIMARY KEY (ID) 
USING INDEX
;

ALTER TABLE CD_MODELE_WEB
ADD CONSTRAINT CD_MODELE_WEB_PK
PRIMARY KEY (CODE) 
USING INDEX
;

ALTER TABLE MODELE_WEB__NODE_WEB
ADD CONSTRAINT MODELE_WEB__NODE_WEB_PK
PRIMARY KEY (NODE_WEB__ID,MODELE_WEB__ID) 
USING INDEX
;

ALTER TABLE NODE_WEB__STYLE_WEB
ADD CONSTRAINT NODE_WEB__STYLE_WEB_PK
PRIMARY KEY (NODE_WEB__ID,STYLE_WEB__ID) 
USING INDEX
;

