/*################################################################################################*/
/* Script     : StartWEB.sql                                                                      */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

set echo off
spool log.txt
connect sys/Emash21@MCDDEV as sysdba
@@CREATION/WEB_Roles.sql
@@CREATION/WEB_Users.sql
@@CREATION/WEB_Schema.sql

connect WEB/WEB@MCDDEV
@@CREATION/WEB_Tables.sql
@@CREATION/WEB_Pks.sql
@@CREATION/WEB_Uks.sql
@@CREATION/WEB_Sequences.sql
@@CREATION/WEB_Triggers.sql
disconnect
connect sys/Emash21@MCDDEV as sysdba
@@CREATION/WEB_PRF_Synonyms.sql
@@CREATION/PRF_Grants.sql
@@CREATION/WEB_INF_Synonyms.sql
@@CREATION/INF_Grants.sql
@@CREATION/WEB_CHS_Synonyms.sql
@@CREATION/CHS_Grants.sql
@@CREATION/WEB_GOT_Synonyms.sql
@@CREATION/GOT_Grants.sql
@@CREATION/WEB_GMS_Synonyms.sql
@@CREATION/GMS_Grants.sql
@@CREATION/WEB_OH_Synonyms.sql
@@CREATION/OH_Grants.sql
@@CREATION/WEB_MAPINFO_Synonyms.sql
@@CREATION/MAPINFO_Grants.sql
@@CREATION/WEB_DS_Synonyms.sql
@@CREATION/DS_Grants.sql
@@CREATION/WEB_OA_Synonyms.sql
@@CREATION/OA_Grants.sql
@@CREATION/WEB_EQP_Synonyms.sql
@@CREATION/EQP_Grants.sql
@@CREATION/WEB_BSN_Synonyms.sql
@@CREATION/BSN_Grants.sql
@@CREATION/WEB_WEB_Synonyms.sql
@@CREATION/WEB_Grants.sql
@@CREATION/PRF_WEB_Synonyms.sql
@@CREATION/INF_WEB_Synonyms.sql
@@CREATION/CHS_WEB_Synonyms.sql
@@CREATION/GOT_WEB_Synonyms.sql
@@CREATION/GMS_WEB_Synonyms.sql
@@CREATION/OH_WEB_Synonyms.sql
@@CREATION/MAPINFO_WEB_Synonyms.sql
@@CREATION/DS_WEB_Synonyms.sql
@@CREATION/OA_WEB_Synonyms.sql
@@CREATION/EQP_WEB_Synonyms.sql
@@CREATION/BSN_WEB_Synonyms.sql
@@CREATION/WEB_Grants.sql
@@CREATION/PRF_Grants.sql
@@INITIALISATION/WEB_SysPrp.sql
@@INITIALISATION/PRF_Data_WEB.sql
disconnect
