/*################################################################################################*/
/* Script     : PRF_Data_WEB.sql                                                                  */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

connect PRF/PRF@MCDDEV
DELETE BM_PARAM;
Insert into BM_PARAM (CODE,VALEUR) values ('SECTION_COURANTE','AUTO');
Insert into BM_PARAM (CODE,VALEUR) values ('IMPORTATION_AUTORISE','TRUE');
DELETE BM_SCHEMA WHERE SCHEMA='WEB';
Insert into BM_SCHEMA (LIBELLE,SCHEMA) values ('Portail Web','WEB');
DELETE BM_PROFIL WHERE BM_SCHEMA__SCHEMA='WEB';
Insert into BM_PROFIL (BM_SCHEMA__SCHEMA,LIBELLE,PROFIL) values ('WEB','Administrateur Portail Web','ADMIN_WEB');
Insert into BM_PROFIL (BM_SCHEMA__SCHEMA,LIBELLE,PROFIL) values ('WEB','Consultant Portail Web','CONSULT_WEB');
Insert into BM_PROFIL (BM_SCHEMA__SCHEMA,LIBELLE,PROFIL) values ('WEB','Valideur Portail Web','VALID_WEB');
DELETE  BM_TABLE WHERE BM_SCHEMA__SCHEMA='WEB';
Insert into BM_TABLE (BM_SCHEMA__SCHEMA,LIBELLE,NOM) values ('WEB','Contenu des modèles','MODELE_WEB__NODE_WEB');
Insert into BM_PROFIL_TABLE (BM_PROFIL__PROFIL,BM_TABLE__NOM,ECRIRE,IMPORTER) values ('VALID_WEB','MODELE_WEB__NODE_WEB',1,0);
Insert into BM_PROFIL_TABLE (BM_PROFIL__PROFIL,BM_TABLE__NOM,ECRIRE,IMPORTER) values ('CONSULT_WEB','MODELE_WEB__NODE_WEB',0,0);
Insert into BM_PROFIL_TABLE (BM_PROFIL__PROFIL,BM_TABLE__NOM,ECRIRE,IMPORTER) values ('ADMIN_WEB','MODELE_WEB__NODE_WEB',1,1);
Insert into BM_TABLE (BM_SCHEMA__SCHEMA,LIBELLE,NOM) values ('WEB','Informations utilisateurs','SYS_USER_WEB');
Insert into BM_PROFIL_TABLE (BM_PROFIL__PROFIL,BM_TABLE__NOM,ECRIRE,IMPORTER) values ('VALID_WEB','SYS_USER_WEB',1,0);
Insert into BM_PROFIL_TABLE (BM_PROFIL__PROFIL,BM_TABLE__NOM,ECRIRE,IMPORTER) values ('CONSULT_WEB','SYS_USER_WEB',0,0);
Insert into BM_PROFIL_TABLE (BM_PROFIL__PROFIL,BM_TABLE__NOM,ECRIRE,IMPORTER) values ('ADMIN_WEB','SYS_USER_WEB',1,1);
Insert into BM_TABLE (BM_SCHEMA__SCHEMA,LIBELLE,NOM) values ('WEB','Modèle','MODELE_WEB');
Insert into BM_PROFIL_TABLE (BM_PROFIL__PROFIL,BM_TABLE__NOM,ECRIRE,IMPORTER) values ('VALID_WEB','MODELE_WEB',1,0);
Insert into BM_PROFIL_TABLE (BM_PROFIL__PROFIL,BM_TABLE__NOM,ECRIRE,IMPORTER) values ('CONSULT_WEB','MODELE_WEB',0,0);
Insert into BM_PROFIL_TABLE (BM_PROFIL__PROFIL,BM_TABLE__NOM,ECRIRE,IMPORTER) values ('ADMIN_WEB','MODELE_WEB',1,1);
Insert into BM_TABLE (BM_SCHEMA__SCHEMA,LIBELLE,NOM) values ('WEB','Noeuds du tableau de bord','NODE_WEB');
Insert into BM_PROFIL_TABLE (BM_PROFIL__PROFIL,BM_TABLE__NOM,ECRIRE,IMPORTER) values ('VALID_WEB','NODE_WEB',1,0);
Insert into BM_PROFIL_TABLE (BM_PROFIL__PROFIL,BM_TABLE__NOM,ECRIRE,IMPORTER) values ('CONSULT_WEB','NODE_WEB',0,0);
Insert into BM_PROFIL_TABLE (BM_PROFIL__PROFIL,BM_TABLE__NOM,ECRIRE,IMPORTER) values ('ADMIN_WEB','NODE_WEB',1,1);
Insert into BM_TABLE (BM_SCHEMA__SCHEMA,LIBELLE,NOM) values ('WEB','Paramètres des noeuds','NODE_PARAM_WEB');
Insert into BM_PROFIL_TABLE (BM_PROFIL__PROFIL,BM_TABLE__NOM,ECRIRE,IMPORTER) values ('VALID_WEB','NODE_PARAM_WEB',1,0);
Insert into BM_PROFIL_TABLE (BM_PROFIL__PROFIL,BM_TABLE__NOM,ECRIRE,IMPORTER) values ('CONSULT_WEB','NODE_PARAM_WEB',0,0);
Insert into BM_PROFIL_TABLE (BM_PROFIL__PROFIL,BM_TABLE__NOM,ECRIRE,IMPORTER) values ('ADMIN_WEB','NODE_PARAM_WEB',1,1);
Insert into BM_TABLE (BM_SCHEMA__SCHEMA,LIBELLE,NOM) values ('WEB','Règles d''un styles (une seul règle si pas analyse)','STYLE_RULE_WEB');
Insert into BM_PROFIL_TABLE (BM_PROFIL__PROFIL,BM_TABLE__NOM,ECRIRE,IMPORTER) values ('VALID_WEB','STYLE_RULE_WEB',1,0);
Insert into BM_PROFIL_TABLE (BM_PROFIL__PROFIL,BM_TABLE__NOM,ECRIRE,IMPORTER) values ('CONSULT_WEB','STYLE_RULE_WEB',0,0);
Insert into BM_PROFIL_TABLE (BM_PROFIL__PROFIL,BM_TABLE__NOM,ECRIRE,IMPORTER) values ('ADMIN_WEB','STYLE_RULE_WEB',1,1);
Insert into BM_TABLE (BM_SCHEMA__SCHEMA,LIBELLE,NOM) values ('WEB','Style d''un couche','STYLE_WEB');
Insert into BM_PROFIL_TABLE (BM_PROFIL__PROFIL,BM_TABLE__NOM,ECRIRE,IMPORTER) values ('VALID_WEB','STYLE_WEB',1,0);
Insert into BM_PROFIL_TABLE (BM_PROFIL__PROFIL,BM_TABLE__NOM,ECRIRE,IMPORTER) values ('CONSULT_WEB','STYLE_WEB',0,0);
Insert into BM_PROFIL_TABLE (BM_PROFIL__PROFIL,BM_TABLE__NOM,ECRIRE,IMPORTER) values ('ADMIN_WEB','STYLE_WEB',1,1);
Insert into BM_TABLE (BM_SCHEMA__SCHEMA,LIBELLE,NOM) values ('WEB','Styles du noeud','NODE_WEB__STYLE_WEB');
Insert into BM_PROFIL_TABLE (BM_PROFIL__PROFIL,BM_TABLE__NOM,ECRIRE,IMPORTER) values ('VALID_WEB','NODE_WEB__STYLE_WEB',1,0);
Insert into BM_PROFIL_TABLE (BM_PROFIL__PROFIL,BM_TABLE__NOM,ECRIRE,IMPORTER) values ('CONSULT_WEB','NODE_WEB__STYLE_WEB',0,0);
Insert into BM_PROFIL_TABLE (BM_PROFIL__PROFIL,BM_TABLE__NOM,ECRIRE,IMPORTER) values ('ADMIN_WEB','NODE_WEB__STYLE_WEB',1,1);
Insert into BM_TABLE (BM_SCHEMA__SCHEMA,LIBELLE,NOM) values ('WEB','Type de modèle (détail schématique synoptique)','CD_MODELE_WEB');
Insert into BM_PROFIL_TABLE (BM_PROFIL__PROFIL,BM_TABLE__NOM,ECRIRE,IMPORTER) values ('VALID_WEB','CD_MODELE_WEB',1,0);
Insert into BM_PROFIL_TABLE (BM_PROFIL__PROFIL,BM_TABLE__NOM,ECRIRE,IMPORTER) values ('CONSULT_WEB','CD_MODELE_WEB',0,0);
Insert into BM_PROFIL_TABLE (BM_PROFIL__PROFIL,BM_TABLE__NOM,ECRIRE,IMPORTER) values ('ADMIN_WEB','CD_MODELE_WEB',1,1);
Insert into BM_TABLE (BM_SCHEMA__SCHEMA,LIBELLE,NOM) values ('WEB','Type de noeud du tableau de bord','CD_NODE_WEB');
Insert into BM_PROFIL_TABLE (BM_PROFIL__PROFIL,BM_TABLE__NOM,ECRIRE,IMPORTER) values ('VALID_WEB','CD_NODE_WEB',1,0);
Insert into BM_PROFIL_TABLE (BM_PROFIL__PROFIL,BM_TABLE__NOM,ECRIRE,IMPORTER) values ('CONSULT_WEB','CD_NODE_WEB',0,0);
Insert into BM_PROFIL_TABLE (BM_PROFIL__PROFIL,BM_TABLE__NOM,ECRIRE,IMPORTER) values ('ADMIN_WEB','CD_NODE_WEB',1,1);
commit;
disconnect
