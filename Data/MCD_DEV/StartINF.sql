/*################################################################################################*/
/* Script     : StartINF.sql                                                                      */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

set echo off
spool log.txt
connect sys/Emash21@MCDDEV as sysdba
@@CREATION/INF_Roles.sql
@@CREATION/INF_Users.sql
@@CREATION/INF_Schema.sql

connect INF/INF@MCDDEV
@@CREATION/INF_Tables.sql
@@CREATION/INF_Pks.sql
@@CREATION/INF_Uks.sql
@@CREATION/INF_Sequences.sql
@@CREATION/INF_Triggers.sql
disconnect
connect sys/Emash21@MCDDEV as sysdba
@@CREATION/INF_PRF_Synonyms.sql
@@CREATION/PRF_Grants.sql
@@CREATION/INF_INF_Synonyms.sql
@@CREATION/INF_Grants.sql
@@CREATION/INF_CHS_Synonyms.sql
@@CREATION/CHS_Grants.sql
@@CREATION/INF_GOT_Synonyms.sql
@@CREATION/GOT_Grants.sql
@@CREATION/INF_GMS_Synonyms.sql
@@CREATION/GMS_Grants.sql
@@CREATION/INF_OH_Synonyms.sql
@@CREATION/OH_Grants.sql
@@CREATION/INF_MAPINFO_Synonyms.sql
@@CREATION/MAPINFO_Grants.sql
@@CREATION/INF_DS_Synonyms.sql
@@CREATION/DS_Grants.sql
@@CREATION/INF_OA_Synonyms.sql
@@CREATION/OA_Grants.sql
@@CREATION/INF_EQP_Synonyms.sql
@@CREATION/EQP_Grants.sql
@@CREATION/INF_BSN_Synonyms.sql
@@CREATION/BSN_Grants.sql
@@CREATION/INF_WEB_Synonyms.sql
@@CREATION/WEB_Grants.sql
@@CREATION/PRF_INF_Synonyms.sql
@@CREATION/CHS_INF_Synonyms.sql
@@CREATION/GOT_INF_Synonyms.sql
@@CREATION/GMS_INF_Synonyms.sql
@@CREATION/OH_INF_Synonyms.sql
@@CREATION/MAPINFO_INF_Synonyms.sql
@@CREATION/DS_INF_Synonyms.sql
@@CREATION/OA_INF_Synonyms.sql
@@CREATION/EQP_INF_Synonyms.sql
@@CREATION/BSN_INF_Synonyms.sql
@@CREATION/WEB_INF_Synonyms.sql
@@CREATION/INF_Grants.sql
@@CREATION/PRF_Grants.sql
@@INITIALISATION/INF_SysPrp.sql
@@INITIALISATION/PRF_Data_INF.sql
disconnect
