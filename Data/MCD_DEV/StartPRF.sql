/*################################################################################################*/
/* Script     : StartPRF.sql                                                                      */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

set echo off
spool log.txt
connect sys/Emash21@MCDDEV as sysdba
@@CREATION/PRF_Roles.sql
@@CREATION/PRF_Users.sql
@@CREATION/PRF_Schema.sql

connect PRF/PRF@MCDDEV
@@CREATION/PRF_Tables.sql
@@CREATION/PRF_Pks.sql
@@CREATION/PRF_Triggers.sql
disconnect
connect sys/Emash21@MCDDEV as sysdba
@@CREATION/PRF_PRF_Synonyms.sql
@@CREATION/PRF_Grants.sql
@@CREATION/PRF_INF_Synonyms.sql
@@CREATION/INF_Grants.sql
@@CREATION/PRF_CHS_Synonyms.sql
@@CREATION/CHS_Grants.sql
@@CREATION/PRF_GOT_Synonyms.sql
@@CREATION/GOT_Grants.sql
@@CREATION/PRF_GMS_Synonyms.sql
@@CREATION/GMS_Grants.sql
@@CREATION/PRF_OH_Synonyms.sql
@@CREATION/OH_Grants.sql
@@CREATION/PRF_MAPINFO_Synonyms.sql
@@CREATION/MAPINFO_Grants.sql
@@CREATION/PRF_DS_Synonyms.sql
@@CREATION/DS_Grants.sql
@@CREATION/PRF_OA_Synonyms.sql
@@CREATION/OA_Grants.sql
@@CREATION/PRF_EQP_Synonyms.sql
@@CREATION/EQP_Grants.sql
@@CREATION/PRF_BSN_Synonyms.sql
@@CREATION/BSN_Grants.sql
@@CREATION/PRF_WEB_Synonyms.sql
@@CREATION/WEB_Grants.sql
@@CREATION/INF_PRF_Synonyms.sql
@@CREATION/CHS_PRF_Synonyms.sql
@@CREATION/GOT_PRF_Synonyms.sql
@@CREATION/GMS_PRF_Synonyms.sql
@@CREATION/OH_PRF_Synonyms.sql
@@CREATION/MAPINFO_PRF_Synonyms.sql
@@CREATION/DS_PRF_Synonyms.sql
@@CREATION/OA_PRF_Synonyms.sql
@@CREATION/EQP_PRF_Synonyms.sql
@@CREATION/BSN_PRF_Synonyms.sql
@@CREATION/WEB_PRF_Synonyms.sql
@@CREATION/PRF_Grants.sql
@@CREATION/PRF_Grants.sql
@@INITIALISATION/PRF_SysPrp.sql
@@INITIALISATION/PRF_Data_PRF.sql
disconnect
