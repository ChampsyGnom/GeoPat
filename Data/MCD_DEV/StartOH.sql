/*################################################################################################*/
/* Script     : StartOH.sql                                                                       */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

set echo off
spool log.txt
connect sys/Emash21@MCDDEV as sysdba
@@CREATION/OH_Roles.sql
@@CREATION/OH_Users.sql
@@CREATION/OH_Schema.sql

connect OH/OH@MCDDEV
@@CREATION/OH_Tables.sql
@@CREATION/OH_Views.sql
@@CREATION/OH_Pks.sql
@@CREATION/OH_Uks.sql
@@CREATION/OH_Sequences.sql
@@CREATION/OH_Triggers.sql
disconnect
connect sys/Emash21@MCDDEV as sysdba
@@CREATION/OH_PRF_Synonyms.sql
@@CREATION/PRF_Grants.sql
@@CREATION/OH_INF_Synonyms.sql
@@CREATION/INF_Grants.sql
@@CREATION/OH_CHS_Synonyms.sql
@@CREATION/CHS_Grants.sql
@@CREATION/OH_GOT_Synonyms.sql
@@CREATION/GOT_Grants.sql
@@CREATION/OH_GMS_Synonyms.sql
@@CREATION/GMS_Grants.sql
@@CREATION/OH_OH_Synonyms.sql
@@CREATION/OH_Grants.sql
@@CREATION/OH_MAPINFO_Synonyms.sql
@@CREATION/MAPINFO_Grants.sql
@@CREATION/OH_DS_Synonyms.sql
@@CREATION/DS_Grants.sql
@@CREATION/OH_OA_Synonyms.sql
@@CREATION/OA_Grants.sql
@@CREATION/OH_EQP_Synonyms.sql
@@CREATION/EQP_Grants.sql
@@CREATION/OH_BSN_Synonyms.sql
@@CREATION/BSN_Grants.sql
@@CREATION/OH_WEB_Synonyms.sql
@@CREATION/WEB_Grants.sql
@@CREATION/PRF_OH_Synonyms.sql
@@CREATION/INF_OH_Synonyms.sql
@@CREATION/CHS_OH_Synonyms.sql
@@CREATION/GOT_OH_Synonyms.sql
@@CREATION/GMS_OH_Synonyms.sql
@@CREATION/MAPINFO_OH_Synonyms.sql
@@CREATION/DS_OH_Synonyms.sql
@@CREATION/OA_OH_Synonyms.sql
@@CREATION/EQP_OH_Synonyms.sql
@@CREATION/BSN_OH_Synonyms.sql
@@CREATION/WEB_OH_Synonyms.sql
@@CREATION/OH_Grants.sql
@@CREATION/PRF_Grants.sql
@@INITIALISATION/OH_SysPrp.sql
@@INITIALISATION/PRF_Data_OH.sql
disconnect
