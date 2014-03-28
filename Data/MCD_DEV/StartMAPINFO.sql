/*################################################################################################*/
/* Script     : StartMAPINFO.sql                                                                  */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

set echo off
spool log.txt
connect sys/Emash21@MCDDEV as sysdba
@@CREATION/MAPINFO_Roles.sql
@@CREATION/MAPINFO_Users.sql
@@CREATION/MAPINFO_Schema.sql

connect MAPINFO/MAPINFO@MCDDEV
@@CREATION/MAPINFO_Tables.sql
@@CREATION/MAPINFO_Pks.sql
@@CREATION/MAPINFO_Triggers.sql
disconnect
connect sys/Emash21@MCDDEV as sysdba
@@CREATION/MAPINFO_PRF_Synonyms.sql
@@CREATION/PRF_Grants.sql
@@CREATION/MAPINFO_INF_Synonyms.sql
@@CREATION/INF_Grants.sql
@@CREATION/MAPINFO_CHS_Synonyms.sql
@@CREATION/CHS_Grants.sql
@@CREATION/MAPINFO_GOT_Synonyms.sql
@@CREATION/GOT_Grants.sql
@@CREATION/MAPINFO_GMS_Synonyms.sql
@@CREATION/GMS_Grants.sql
@@CREATION/MAPINFO_OH_Synonyms.sql
@@CREATION/OH_Grants.sql
@@CREATION/MAPINFO_MAPINFO_Synonyms.sql
@@CREATION/MAPINFO_Grants.sql
@@CREATION/MAPINFO_DS_Synonyms.sql
@@CREATION/DS_Grants.sql
@@CREATION/MAPINFO_OA_Synonyms.sql
@@CREATION/OA_Grants.sql
@@CREATION/MAPINFO_EQP_Synonyms.sql
@@CREATION/EQP_Grants.sql
@@CREATION/MAPINFO_BSN_Synonyms.sql
@@CREATION/BSN_Grants.sql
@@CREATION/MAPINFO_WEB_Synonyms.sql
@@CREATION/WEB_Grants.sql
@@CREATION/PRF_MAPINFO_Synonyms.sql
@@CREATION/INF_MAPINFO_Synonyms.sql
@@CREATION/CHS_MAPINFO_Synonyms.sql
@@CREATION/GOT_MAPINFO_Synonyms.sql
@@CREATION/GMS_MAPINFO_Synonyms.sql
@@CREATION/OH_MAPINFO_Synonyms.sql
@@CREATION/DS_MAPINFO_Synonyms.sql
@@CREATION/OA_MAPINFO_Synonyms.sql
@@CREATION/EQP_MAPINFO_Synonyms.sql
@@CREATION/BSN_MAPINFO_Synonyms.sql
@@CREATION/WEB_MAPINFO_Synonyms.sql
@@CREATION/MAPINFO_Grants.sql
@@CREATION/PRF_Grants.sql
@@INITIALISATION/MAPINFO_SysPrp.sql
@@INITIALISATION/PRF_Data_MAPINFO.sql
disconnect
