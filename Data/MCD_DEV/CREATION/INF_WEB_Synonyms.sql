/*################################################################################################*/
/* Script     : INF_WEB_Synonyms.sql                                                              */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

CREATE OR REPLACE  SYNONYM WEB_ADMIN.SYS_INSTANCE_INF FOR INF.SYS_INSTANCE_INF;
CREATE OR REPLACE  SYNONYM WEB_VALID.SYS_INSTANCE_INF FOR INF.SYS_INSTANCE_INF;
CREATE OR REPLACE  SYNONYM WEB_CONSULT.SYS_INSTANCE_INF FOR INF.SYS_INSTANCE_INF;
-- Synonym du role INF_ADMIN pour le sch�ma WEB
CREATE OR REPLACE SYNONYM INF_ADMIN.MODELE_WEB__NODE_WEB FOR WEB.MODELE_WEB__NODE_WEB;
CREATE OR REPLACE SYNONYM INF_ADMIN.SYS_USER_WEB FOR WEB.SYS_USER_WEB;
CREATE OR REPLACE SYNONYM INF_ADMIN.MODELE_WEB FOR WEB.MODELE_WEB;
CREATE OR REPLACE SYNONYM INF_ADMIN.NODE_WEB FOR WEB.NODE_WEB;
CREATE OR REPLACE SYNONYM INF_ADMIN.NODE_PARAM_WEB FOR WEB.NODE_PARAM_WEB;
CREATE OR REPLACE SYNONYM INF_ADMIN.STYLE_RULE_WEB FOR WEB.STYLE_RULE_WEB;
CREATE OR REPLACE SYNONYM INF_ADMIN.STYLE_WEB FOR WEB.STYLE_WEB;
CREATE OR REPLACE SYNONYM INF_ADMIN.NODE_WEB__STYLE_WEB FOR WEB.NODE_WEB__STYLE_WEB;
CREATE OR REPLACE SYNONYM INF_ADMIN.CD_MODELE_WEB FOR WEB.CD_MODELE_WEB;
CREATE OR REPLACE SYNONYM INF_ADMIN.CD_NODE_WEB FOR WEB.CD_NODE_WEB;
CREATE OR REPLACE  SYNONYM INF_ADMIN.SYS_PRP_WEB FOR WEB.SYS_PRP_WEB;
CREATE OR REPLACE  SYNONYM INF_ADMIN.SEQ_NODE_WEB FOR WEB.SEQ_NODE_WEB;
CREATE OR REPLACE  SYNONYM INF_ADMIN.SEQ_STYLE_WEB FOR WEB.SEQ_STYLE_WEB;
CREATE OR REPLACE  SYNONYM INF_ADMIN.SEQ_STYLE_RULE_WEB FOR WEB.SEQ_STYLE_RULE_WEB;
CREATE OR REPLACE  SYNONYM INF_ADMIN.SEQ_MODELE_WEB FOR WEB.SEQ_MODELE_WEB;
-- Synonym du role INF_CONSULT pour le sch�ma WEB
CREATE OR REPLACE SYNONYM INF_CONSULT.MODELE_WEB__NODE_WEB FOR WEB.MODELE_WEB__NODE_WEB;
CREATE OR REPLACE SYNONYM INF_CONSULT.SYS_USER_WEB FOR WEB.SYS_USER_WEB;
CREATE OR REPLACE SYNONYM INF_CONSULT.MODELE_WEB FOR WEB.MODELE_WEB;
CREATE OR REPLACE SYNONYM INF_CONSULT.NODE_WEB FOR WEB.NODE_WEB;
CREATE OR REPLACE SYNONYM INF_CONSULT.NODE_PARAM_WEB FOR WEB.NODE_PARAM_WEB;
CREATE OR REPLACE SYNONYM INF_CONSULT.STYLE_RULE_WEB FOR WEB.STYLE_RULE_WEB;
CREATE OR REPLACE SYNONYM INF_CONSULT.STYLE_WEB FOR WEB.STYLE_WEB;
CREATE OR REPLACE SYNONYM INF_CONSULT.NODE_WEB__STYLE_WEB FOR WEB.NODE_WEB__STYLE_WEB;
CREATE OR REPLACE SYNONYM INF_CONSULT.CD_MODELE_WEB FOR WEB.CD_MODELE_WEB;
CREATE OR REPLACE SYNONYM INF_CONSULT.CD_NODE_WEB FOR WEB.CD_NODE_WEB;
CREATE OR REPLACE  SYNONYM INF_CONSULT.SYS_PRP_WEB FOR WEB.SYS_PRP_WEB;
CREATE OR REPLACE  SYNONYM INF_CONSULT.SEQ_NODE_WEB FOR WEB.SEQ_NODE_WEB;
CREATE OR REPLACE  SYNONYM INF_CONSULT.SEQ_STYLE_WEB FOR WEB.SEQ_STYLE_WEB;
CREATE OR REPLACE  SYNONYM INF_CONSULT.SEQ_STYLE_RULE_WEB FOR WEB.SEQ_STYLE_RULE_WEB;
CREATE OR REPLACE  SYNONYM INF_CONSULT.SEQ_MODELE_WEB FOR WEB.SEQ_MODELE_WEB;
-- Synonym du role INF_VALID pour le sch�ma WEB
CREATE OR REPLACE SYNONYM INF_VALID.MODELE_WEB__NODE_WEB FOR WEB.MODELE_WEB__NODE_WEB;
CREATE OR REPLACE SYNONYM INF_VALID.SYS_USER_WEB FOR WEB.SYS_USER_WEB;
CREATE OR REPLACE SYNONYM INF_VALID.MODELE_WEB FOR WEB.MODELE_WEB;
CREATE OR REPLACE SYNONYM INF_VALID.NODE_WEB FOR WEB.NODE_WEB;
CREATE OR REPLACE SYNONYM INF_VALID.NODE_PARAM_WEB FOR WEB.NODE_PARAM_WEB;
CREATE OR REPLACE SYNONYM INF_VALID.STYLE_RULE_WEB FOR WEB.STYLE_RULE_WEB;
CREATE OR REPLACE SYNONYM INF_VALID.STYLE_WEB FOR WEB.STYLE_WEB;
CREATE OR REPLACE SYNONYM INF_VALID.NODE_WEB__STYLE_WEB FOR WEB.NODE_WEB__STYLE_WEB;
CREATE OR REPLACE SYNONYM INF_VALID.CD_MODELE_WEB FOR WEB.CD_MODELE_WEB;
CREATE OR REPLACE SYNONYM INF_VALID.CD_NODE_WEB FOR WEB.CD_NODE_WEB;
CREATE OR REPLACE  SYNONYM INF_VALID.SYS_PRP_WEB FOR WEB.SYS_PRP_WEB;
CREATE OR REPLACE  SYNONYM INF_VALID.SEQ_NODE_WEB FOR WEB.SEQ_NODE_WEB;
CREATE OR REPLACE  SYNONYM INF_VALID.SEQ_STYLE_WEB FOR WEB.SEQ_STYLE_WEB;
CREATE OR REPLACE  SYNONYM INF_VALID.SEQ_STYLE_RULE_WEB FOR WEB.SEQ_STYLE_RULE_WEB;
CREATE OR REPLACE  SYNONYM INF_VALID.SEQ_MODELE_WEB FOR WEB.SEQ_MODELE_WEB;
