/*################################################################################################*/
/* Script     : StartOA.sql                                                                       */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

set echo off
spool log.txt
connect sys/Emash21@MCDDEV as sysdba
@@CREATION/OA_Roles.sql
@@CREATION/OA_Users.sql
@@CREATION/OA_Schema.sql

connect OA/OA@MCDDEV
@@CREATION/OA_Tables.sql
@@CREATION/OA_Views.sql
@@CREATION/OA_Pks.sql
@@CREATION/OA_Uks.sql
@@CREATION/OA_Sequences.sql
@@CREATION/OA_Triggers.sql
disconnect
connect sys/Emash21@MCDDEV as sysdba
@@CREATION/OA_PRF_Synonyms.sql
@@CREATION/PRF_Grants.sql
@@CREATION/OA_INF_Synonyms.sql
@@CREATION/INF_Grants.sql
@@CREATION/OA_CHS_Synonyms.sql
@@CREATION/CHS_Grants.sql
@@CREATION/OA_GOT_Synonyms.sql
@@CREATION/GOT_Grants.sql
@@CREATION/OA_GMS_Synonyms.sql
@@CREATION/GMS_Grants.sql
@@CREATION/OA_OH_Synonyms.sql
@@CREATION/OH_Grants.sql
@@CREATION/OA_MAPINFO_Synonyms.sql
@@CREATION/MAPINFO_Grants.sql
@@CREATION/OA_DS_Synonyms.sql
@@CREATION/DS_Grants.sql
@@CREATION/OA_OA_Synonyms.sql
@@CREATION/OA_Grants.sql
@@CREATION/OA_EQP_Synonyms.sql
@@CREATION/EQP_Grants.sql
@@CREATION/OA_BSN_Synonyms.sql
@@CREATION/BSN_Grants.sql
@@CREATION/OA_WEB_Synonyms.sql
@@CREATION/WEB_Grants.sql
@@CREATION/PRF_OA_Synonyms.sql
@@CREATION/INF_OA_Synonyms.sql
@@CREATION/CHS_OA_Synonyms.sql
@@CREATION/GOT_OA_Synonyms.sql
@@CREATION/GMS_OA_Synonyms.sql
@@CREATION/OH_OA_Synonyms.sql
@@CREATION/MAPINFO_OA_Synonyms.sql
@@CREATION/DS_OA_Synonyms.sql
@@CREATION/EQP_OA_Synonyms.sql
@@CREATION/BSN_OA_Synonyms.sql
@@CREATION/WEB_OA_Synonyms.sql
@@CREATION/OA_Grants.sql
@@CREATION/PRF_Grants.sql
@@INITIALISATION/OA_SysPrp.sql
@@INITIALISATION/PRF_Data_OA.sql
disconnect
