/*################################################################################################*/
/* Script     : StartDS.sql                                                                       */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

set echo off
spool log.txt
connect sys/Emash21@MCDDEV as sysdba
@@CREATION/DS_Roles.sql
@@CREATION/DS_Users.sql
@@CREATION/DS_Schema.sql

connect DS/DS@MCDDEV
@@CREATION/DS_Tables.sql
@@CREATION/DS_Pks.sql
@@CREATION/DS_Triggers.sql
disconnect
connect sys/Emash21@MCDDEV as sysdba
@@CREATION/DS_PRF_Synonyms.sql
@@CREATION/PRF_Grants.sql
@@CREATION/DS_INF_Synonyms.sql
@@CREATION/INF_Grants.sql
@@CREATION/DS_CHS_Synonyms.sql
@@CREATION/CHS_Grants.sql
@@CREATION/DS_GOT_Synonyms.sql
@@CREATION/GOT_Grants.sql
@@CREATION/DS_GMS_Synonyms.sql
@@CREATION/GMS_Grants.sql
@@CREATION/DS_OH_Synonyms.sql
@@CREATION/OH_Grants.sql
@@CREATION/DS_MAPINFO_Synonyms.sql
@@CREATION/MAPINFO_Grants.sql
@@CREATION/DS_DS_Synonyms.sql
@@CREATION/DS_Grants.sql
@@CREATION/DS_OA_Synonyms.sql
@@CREATION/OA_Grants.sql
@@CREATION/DS_EQP_Synonyms.sql
@@CREATION/EQP_Grants.sql
@@CREATION/DS_BSN_Synonyms.sql
@@CREATION/BSN_Grants.sql
@@CREATION/DS_WEB_Synonyms.sql
@@CREATION/WEB_Grants.sql
@@CREATION/PRF_DS_Synonyms.sql
@@CREATION/INF_DS_Synonyms.sql
@@CREATION/CHS_DS_Synonyms.sql
@@CREATION/GOT_DS_Synonyms.sql
@@CREATION/GMS_DS_Synonyms.sql
@@CREATION/OH_DS_Synonyms.sql
@@CREATION/MAPINFO_DS_Synonyms.sql
@@CREATION/OA_DS_Synonyms.sql
@@CREATION/EQP_DS_Synonyms.sql
@@CREATION/BSN_DS_Synonyms.sql
@@CREATION/WEB_DS_Synonyms.sql
@@CREATION/DS_Grants.sql
@@CREATION/PRF_Grants.sql
@@INITIALISATION/DS_SysPrp.sql
@@INITIALISATION/PRF_Data_DS.sql
disconnect
