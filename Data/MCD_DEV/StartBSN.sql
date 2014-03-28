/*################################################################################################*/
/* Script     : StartBSN.sql                                                                      */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

set echo off
spool log.txt
connect sys/Emash21@MCDDEV as sysdba
@@CREATION/BSN_Roles.sql
@@CREATION/BSN_Users.sql
@@CREATION/BSN_Schema.sql

connect BSN/BSN@MCDDEV
@@CREATION/BSN_Tables.sql
@@CREATION/BSN_Views.sql
@@CREATION/BSN_Pks.sql
@@CREATION/BSN_Uks.sql
@@CREATION/BSN_Sequences.sql
@@CREATION/BSN_Triggers.sql
disconnect
connect sys/Emash21@MCDDEV as sysdba
@@CREATION/BSN_PRF_Synonyms.sql
@@CREATION/PRF_Grants.sql
@@CREATION/BSN_INF_Synonyms.sql
@@CREATION/INF_Grants.sql
@@CREATION/BSN_CHS_Synonyms.sql
@@CREATION/CHS_Grants.sql
@@CREATION/BSN_GOT_Synonyms.sql
@@CREATION/GOT_Grants.sql
@@CREATION/BSN_GMS_Synonyms.sql
@@CREATION/GMS_Grants.sql
@@CREATION/BSN_OH_Synonyms.sql
@@CREATION/OH_Grants.sql
@@CREATION/BSN_MAPINFO_Synonyms.sql
@@CREATION/MAPINFO_Grants.sql
@@CREATION/BSN_DS_Synonyms.sql
@@CREATION/DS_Grants.sql
@@CREATION/BSN_OA_Synonyms.sql
@@CREATION/OA_Grants.sql
@@CREATION/BSN_EQP_Synonyms.sql
@@CREATION/EQP_Grants.sql
@@CREATION/BSN_BSN_Synonyms.sql
@@CREATION/BSN_Grants.sql
@@CREATION/BSN_WEB_Synonyms.sql
@@CREATION/WEB_Grants.sql
@@CREATION/PRF_BSN_Synonyms.sql
@@CREATION/INF_BSN_Synonyms.sql
@@CREATION/CHS_BSN_Synonyms.sql
@@CREATION/GOT_BSN_Synonyms.sql
@@CREATION/GMS_BSN_Synonyms.sql
@@CREATION/OH_BSN_Synonyms.sql
@@CREATION/MAPINFO_BSN_Synonyms.sql
@@CREATION/DS_BSN_Synonyms.sql
@@CREATION/OA_BSN_Synonyms.sql
@@CREATION/EQP_BSN_Synonyms.sql
@@CREATION/WEB_BSN_Synonyms.sql
@@CREATION/BSN_Grants.sql
@@CREATION/PRF_Grants.sql
@@INITIALISATION/BSN_SysPrp.sql
@@INITIALISATION/PRF_Data_BSN.sql
disconnect
