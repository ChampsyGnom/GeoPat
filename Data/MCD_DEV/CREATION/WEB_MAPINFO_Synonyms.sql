/*################################################################################################*/
/* Script     : WEB_MAPINFO_Synonyms.sql                                                          */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

CREATE OR REPLACE  SYNONYM MAPINFO_ADMIN.SYS_INSTANCE_WEB FOR WEB.SYS_INSTANCE_WEB;
CREATE OR REPLACE  SYNONYM MAPINFO_VALID.SYS_INSTANCE_WEB FOR WEB.SYS_INSTANCE_WEB;
CREATE OR REPLACE  SYNONYM MAPINFO_CONSULT.SYS_INSTANCE_WEB FOR WEB.SYS_INSTANCE_WEB;
-- Synonym du role WEB_ADMIN pour le sch�ma MAPINFO
CREATE OR REPLACE SYNONYM WEB_ADMIN.TB_MAP FOR MAPINFO.TB_MAP;
CREATE OR REPLACE SYNONYM WEB_ADMIN.TB_MAP_CFG FOR MAPINFO.TB_MAP_CFG;
CREATE OR REPLACE SYNONYM WEB_ADMIN.TB_GROUPE_CFG FOR MAPINFO.TB_GROUPE_CFG;
CREATE OR REPLACE SYNONYM WEB_ADMIN.TB_MODELE_CFG FOR MAPINFO.TB_MODELE_CFG;
CREATE OR REPLACE SYNONYM WEB_ADMIN.TB_TEMPLATE_CFG FOR MAPINFO.TB_TEMPLATE_CFG;
CREATE OR REPLACE SYNONYM WEB_ADMIN.TB_GROUPE FOR MAPINFO.TB_GROUPE;
CREATE OR REPLACE SYNONYM WEB_ADMIN.TB_MODELE FOR MAPINFO.TB_MODELE;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_MOTS_RESERVE FOR MAPINFO.CD_MOTS_RESERVE;
CREATE OR REPLACE SYNONYM WEB_ADMIN.TB_ANA_THEMA FOR MAPINFO.TB_ANA_THEMA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.SI_MODEL_PREDEF FOR MAPINFO.SI_MODEL_PREDEF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.SI_PRP FOR MAPINFO.SI_PRP;
CREATE OR REPLACE SYNONYM WEB_ADMIN.SI_STYLE_VALEUR FOR MAPINFO.SI_STYLE_VALEUR;
CREATE OR REPLACE SYNONYM WEB_ADMIN.SI_ZONE FOR MAPINFO.SI_ZONE;
CREATE OR REPLACE SYNONYM WEB_ADMIN.SI_MODEL FOR MAPINFO.SI_MODEL;
CREATE OR REPLACE SYNONYM WEB_ADMIN.SYS_USER_MAPINFO FOR MAPINFO.SYS_USER_MAPINFO;
CREATE OR REPLACE SYNONYM WEB_ADMIN.TB_MAP_METIER FOR MAPINFO.TB_MAP_METIER;
CREATE OR REPLACE SYNONYM WEB_ADMIN.TB_MAP_METIER_CFG FOR MAPINFO.TB_MAP_METIER_CFG;
CREATE OR REPLACE SYNONYM WEB_ADMIN.TB_MAP_METIER_COLUMNS FOR MAPINFO.TB_MAP_METIER_COLUMNS;
CREATE OR REPLACE SYNONYM WEB_ADMIN.TB_MAP_GEO_STYLE FOR MAPINFO.TB_MAP_GEO_STYLE;
CREATE OR REPLACE SYNONYM WEB_ADMIN.TB_TEMPLATE FOR MAPINFO.TB_TEMPLATE;
CREATE OR REPLACE  SYNONYM WEB_ADMIN.SYS_PRP_MAPINFO FOR MAPINFO.SYS_PRP_MAPINFO;
-- Synonym du role WEB_CONSULT pour le sch�ma MAPINFO
CREATE OR REPLACE SYNONYM WEB_CONSULT.TB_MAP FOR MAPINFO.TB_MAP;
CREATE OR REPLACE SYNONYM WEB_CONSULT.TB_MAP_CFG FOR MAPINFO.TB_MAP_CFG;
CREATE OR REPLACE SYNONYM WEB_CONSULT.TB_GROUPE_CFG FOR MAPINFO.TB_GROUPE_CFG;
CREATE OR REPLACE SYNONYM WEB_CONSULT.TB_MODELE_CFG FOR MAPINFO.TB_MODELE_CFG;
CREATE OR REPLACE SYNONYM WEB_CONSULT.TB_TEMPLATE_CFG FOR MAPINFO.TB_TEMPLATE_CFG;
CREATE OR REPLACE SYNONYM WEB_CONSULT.TB_GROUPE FOR MAPINFO.TB_GROUPE;
CREATE OR REPLACE SYNONYM WEB_CONSULT.TB_MODELE FOR MAPINFO.TB_MODELE;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_MOTS_RESERVE FOR MAPINFO.CD_MOTS_RESERVE;
CREATE OR REPLACE SYNONYM WEB_CONSULT.TB_ANA_THEMA FOR MAPINFO.TB_ANA_THEMA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.SI_MODEL_PREDEF FOR MAPINFO.SI_MODEL_PREDEF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.SI_PRP FOR MAPINFO.SI_PRP;
CREATE OR REPLACE SYNONYM WEB_CONSULT.SI_STYLE_VALEUR FOR MAPINFO.SI_STYLE_VALEUR;
CREATE OR REPLACE SYNONYM WEB_CONSULT.SI_ZONE FOR MAPINFO.SI_ZONE;
CREATE OR REPLACE SYNONYM WEB_CONSULT.SI_MODEL FOR MAPINFO.SI_MODEL;
CREATE OR REPLACE SYNONYM WEB_CONSULT.SYS_USER_MAPINFO FOR MAPINFO.SYS_USER_MAPINFO;
CREATE OR REPLACE SYNONYM WEB_CONSULT.TB_MAP_METIER FOR MAPINFO.TB_MAP_METIER;
CREATE OR REPLACE SYNONYM WEB_CONSULT.TB_MAP_METIER_CFG FOR MAPINFO.TB_MAP_METIER_CFG;
CREATE OR REPLACE SYNONYM WEB_CONSULT.TB_MAP_METIER_COLUMNS FOR MAPINFO.TB_MAP_METIER_COLUMNS;
CREATE OR REPLACE SYNONYM WEB_CONSULT.TB_MAP_GEO_STYLE FOR MAPINFO.TB_MAP_GEO_STYLE;
CREATE OR REPLACE SYNONYM WEB_CONSULT.TB_TEMPLATE FOR MAPINFO.TB_TEMPLATE;
CREATE OR REPLACE  SYNONYM WEB_CONSULT.SYS_PRP_MAPINFO FOR MAPINFO.SYS_PRP_MAPINFO;
-- Synonym du role WEB_VALID pour le sch�ma MAPINFO
CREATE OR REPLACE SYNONYM WEB_VALID.TB_MAP FOR MAPINFO.TB_MAP;
CREATE OR REPLACE SYNONYM WEB_VALID.TB_MAP_CFG FOR MAPINFO.TB_MAP_CFG;
CREATE OR REPLACE SYNONYM WEB_VALID.TB_GROUPE_CFG FOR MAPINFO.TB_GROUPE_CFG;
CREATE OR REPLACE SYNONYM WEB_VALID.TB_MODELE_CFG FOR MAPINFO.TB_MODELE_CFG;
CREATE OR REPLACE SYNONYM WEB_VALID.TB_TEMPLATE_CFG FOR MAPINFO.TB_TEMPLATE_CFG;
CREATE OR REPLACE SYNONYM WEB_VALID.TB_GROUPE FOR MAPINFO.TB_GROUPE;
CREATE OR REPLACE SYNONYM WEB_VALID.TB_MODELE FOR MAPINFO.TB_MODELE;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_MOTS_RESERVE FOR MAPINFO.CD_MOTS_RESERVE;
CREATE OR REPLACE SYNONYM WEB_VALID.TB_ANA_THEMA FOR MAPINFO.TB_ANA_THEMA;
CREATE OR REPLACE SYNONYM WEB_VALID.SI_MODEL_PREDEF FOR MAPINFO.SI_MODEL_PREDEF;
CREATE OR REPLACE SYNONYM WEB_VALID.SI_PRP FOR MAPINFO.SI_PRP;
CREATE OR REPLACE SYNONYM WEB_VALID.SI_STYLE_VALEUR FOR MAPINFO.SI_STYLE_VALEUR;
CREATE OR REPLACE SYNONYM WEB_VALID.SI_ZONE FOR MAPINFO.SI_ZONE;
CREATE OR REPLACE SYNONYM WEB_VALID.SI_MODEL FOR MAPINFO.SI_MODEL;
CREATE OR REPLACE SYNONYM WEB_VALID.SYS_USER_MAPINFO FOR MAPINFO.SYS_USER_MAPINFO;
CREATE OR REPLACE SYNONYM WEB_VALID.TB_MAP_METIER FOR MAPINFO.TB_MAP_METIER;
CREATE OR REPLACE SYNONYM WEB_VALID.TB_MAP_METIER_CFG FOR MAPINFO.TB_MAP_METIER_CFG;
CREATE OR REPLACE SYNONYM WEB_VALID.TB_MAP_METIER_COLUMNS FOR MAPINFO.TB_MAP_METIER_COLUMNS;
CREATE OR REPLACE SYNONYM WEB_VALID.TB_MAP_GEO_STYLE FOR MAPINFO.TB_MAP_GEO_STYLE;
CREATE OR REPLACE SYNONYM WEB_VALID.TB_TEMPLATE FOR MAPINFO.TB_TEMPLATE;
CREATE OR REPLACE  SYNONYM WEB_VALID.SYS_PRP_MAPINFO FOR MAPINFO.SYS_PRP_MAPINFO;
