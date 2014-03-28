/*################################################################################################*/
/* Script     : OH_PRF_Synonyms.sql                                                               */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

CREATE OR REPLACE  SYNONYM PRF_ADMIN.SYS_INSTANCE_OH FOR OH.SYS_INSTANCE_OH;
CREATE OR REPLACE  SYNONYM PRF_CONSULT.SYS_INSTANCE_OH FOR OH.SYS_INSTANCE_OH;
-- Synonym du role OH_ADMIN pour le sch�ma PRF
CREATE OR REPLACE SYNONYM OH_ADMIN.BM_PROFIL_TABLE FOR PRF.BM_PROFIL_TABLE;
CREATE OR REPLACE SYNONYM OH_ADMIN.BM_PARAM FOR PRF.BM_PARAM;
CREATE OR REPLACE SYNONYM OH_ADMIN.BM_PROFIL FOR PRF.BM_PROFIL;
CREATE OR REPLACE SYNONYM OH_ADMIN.BM_USER_PROFIL FOR PRF.BM_USER_PROFIL;
CREATE OR REPLACE SYNONYM OH_ADMIN.BM_SCHEMA FOR PRF.BM_SCHEMA;
CREATE OR REPLACE SYNONYM OH_ADMIN.SYS_LANG FOR PRF.SYS_LANG;
CREATE OR REPLACE SYNONYM OH_ADMIN.BM_TABLE FOR PRF.BM_TABLE;
CREATE OR REPLACE SYNONYM OH_ADMIN.BM_USER FOR PRF.BM_USER;
CREATE OR REPLACE  SYNONYM OH_ADMIN.SYS_PRP_PRF FOR PRF.SYS_PRP_PRF;
-- Synonym du role OH_CONSULT pour le sch�ma PRF
CREATE OR REPLACE SYNONYM OH_CONSULT.BM_PROFIL_TABLE FOR PRF.BM_PROFIL_TABLE;
CREATE OR REPLACE SYNONYM OH_CONSULT.BM_PARAM FOR PRF.BM_PARAM;
CREATE OR REPLACE SYNONYM OH_CONSULT.BM_PROFIL FOR PRF.BM_PROFIL;
CREATE OR REPLACE SYNONYM OH_CONSULT.BM_USER_PROFIL FOR PRF.BM_USER_PROFIL;
CREATE OR REPLACE SYNONYM OH_CONSULT.BM_SCHEMA FOR PRF.BM_SCHEMA;
CREATE OR REPLACE SYNONYM OH_CONSULT.SYS_LANG FOR PRF.SYS_LANG;
CREATE OR REPLACE SYNONYM OH_CONSULT.BM_TABLE FOR PRF.BM_TABLE;
CREATE OR REPLACE SYNONYM OH_CONSULT.BM_USER FOR PRF.BM_USER;
CREATE OR REPLACE  SYNONYM OH_CONSULT.SYS_PRP_PRF FOR PRF.SYS_PRP_PRF;
-- Synonym du role OH_VALID pour le sch�ma PRF
CREATE OR REPLACE SYNONYM OH_VALID.BM_PROFIL_TABLE FOR PRF.BM_PROFIL_TABLE;
CREATE OR REPLACE SYNONYM OH_VALID.BM_PARAM FOR PRF.BM_PARAM;
CREATE OR REPLACE SYNONYM OH_VALID.BM_PROFIL FOR PRF.BM_PROFIL;
CREATE OR REPLACE SYNONYM OH_VALID.BM_USER_PROFIL FOR PRF.BM_USER_PROFIL;
CREATE OR REPLACE SYNONYM OH_VALID.BM_SCHEMA FOR PRF.BM_SCHEMA;
CREATE OR REPLACE SYNONYM OH_VALID.SYS_LANG FOR PRF.SYS_LANG;
CREATE OR REPLACE SYNONYM OH_VALID.BM_TABLE FOR PRF.BM_TABLE;
CREATE OR REPLACE SYNONYM OH_VALID.BM_USER FOR PRF.BM_USER;
CREATE OR REPLACE  SYNONYM OH_VALID.SYS_PRP_PRF FOR PRF.SYS_PRP_PRF;
