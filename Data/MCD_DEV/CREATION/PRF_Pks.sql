/*################################################################################################*/
/* Script     : PRF_Pks.sql                                                                       */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

ALTER TABLE BM_USER
ADD CONSTRAINT BM_USER_PK
PRIMARY KEY (LOGIN) 
USING INDEX
;

ALTER TABLE BM_SCHEMA
ADD CONSTRAINT BM_SCHEMA_PK
PRIMARY KEY (SCHEMA) 
USING INDEX
;

ALTER TABLE BM_TABLE
ADD CONSTRAINT BM_TABLE_PK
PRIMARY KEY (NOM) 
USING INDEX
;

ALTER TABLE BM_PROFIL
ADD CONSTRAINT BM_PROFIL_PK
PRIMARY KEY (PROFIL) 
USING INDEX
;

ALTER TABLE SYS_LANG
ADD CONSTRAINT SYS_LANG_PK
PRIMARY KEY (CODE_APP,CODE_PRP) 
USING INDEX
;

ALTER TABLE BM_PARAM
ADD CONSTRAINT BM_PARAM_PK
PRIMARY KEY (CODE) 
USING INDEX
;

ALTER TABLE BM_PROFIL_TABLE
ADD CONSTRAINT BM_PROFIL_TABLE_PK
PRIMARY KEY (BM_PROFIL__PROFIL,BM_TABLE__NOM) 
USING INDEX
;

ALTER TABLE BM_USER_PROFIL
ADD CONSTRAINT BM_USER_PROFIL_PK
PRIMARY KEY (BM_USER__LOGIN,BM_PROFIL__PROFIL) 
USING INDEX
;

