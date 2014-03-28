/*################################################################################################*/
/* Script     : Start.sql                                                                         */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

set echo off
spool log.txt
connect sys/Emash21@MCDDEV as sysdba
-- Scripts systemes
@@SystemModifSys.sql
@@MetierStandartRole.sql

-- Roles metiers
@@PRF_Roles.sql
@@INF_Roles.sql
@@OH_Roles.sql
@@MAPINFO_Roles.sql
@@DS_Roles.sql
@@OA_Roles.sql
@@BSN_Roles.sql
@@WEB_Roles.sql

-- Users metiers
@@PRF_Users.sql
@@INF_Users.sql
@@OH_Users.sql
@@MAPINFO_Users.sql
@@DS_Users.sql
@@OA_Users.sql
@@BSN_Users.sql
@@WEB_Users.sql

-- Schemas metiers
@@PRF_Schema.sql
@@INF_Schema.sql
@@OH_Schema.sql
@@MAPINFO_Schema.sql
@@DS_Schema.sql
@@OA_Schema.sql
@@BSN_Schema.sql
@@WEB_Schema.sql
disconnect

-- Schema PRF
connect PRF/PRF@MCDDEV
@@PRF_Tables.sql
@@PRF_Pks.sql
@@PRF_Triggers.sql
disconnect

-- Schema INF
connect INF/INF@MCDDEV
@@INF_Tables.sql
@@INF_Pks.sql
@@INF_Uks.sql
@@INF_Sequences.sql
@@INF_Function.sql
@@INF_Triggers.sql
disconnect

-- Schema OH
connect OH/OH@MCDDEV
@@OH_Tables.sql
@@OH_Views.sql
@@OH_Pks.sql
@@OH_Uks.sql
@@OH_Sequences.sql
@@OH_Triggers.sql
disconnect

-- Schema MAPINFO
connect MAPINFO/MAPINFO@MCDDEV
@@MAPINFO_Tables.sql
@@MAPINFO_Pks.sql
@@MAPINFO_Triggers.sql
disconnect

-- Schema DS
connect DS/DS@MCDDEV
@@DS_Tables.sql
@@DS_Pks.sql
@@DS_Triggers.sql
disconnect

-- Schema OA
connect OA/OA@MCDDEV
@@OA_Tables.sql
@@OA_Views.sql
@@OA_Pks.sql
@@OA_Uks.sql
@@OA_Sequences.sql
@@OA_Triggers.sql
disconnect

-- Schema BSN
connect BSN/BSN@MCDDEV
@@BSN_Tables.sql
@@BSN_Views.sql
@@BSN_Pks.sql
@@BSN_Uks.sql
@@BSN_Sequences.sql
@@BSN_Triggers.sql
disconnect

-- Schema WEB
connect WEB/WEB@MCDDEV
@@WEB_Tables.sql
@@WEB_Pks.sql
@@WEB_Uks.sql
@@WEB_Sequences.sql
@@WEB_Triggers.sql
disconnect

-- Synonym metiers
connect sys/Emash21@MCDDEV as sysdba
@@PRF_PRF_Synonyms.sql
@@PRF_INF_Synonyms.sql
@@PRF_OH_Synonyms.sql
@@PRF_MAPINFO_Synonyms.sql
@@PRF_DS_Synonyms.sql
@@PRF_OA_Synonyms.sql
@@PRF_BSN_Synonyms.sql
@@PRF_WEB_Synonyms.sql
@@INF_PRF_Synonyms.sql
@@INF_INF_Synonyms.sql
@@INF_OH_Synonyms.sql
@@INF_MAPINFO_Synonyms.sql
@@INF_DS_Synonyms.sql
@@INF_OA_Synonyms.sql
@@INF_BSN_Synonyms.sql
@@INF_WEB_Synonyms.sql
@@OH_PRF_Synonyms.sql
@@OH_INF_Synonyms.sql
@@OH_OH_Synonyms.sql
@@OH_MAPINFO_Synonyms.sql
@@OH_DS_Synonyms.sql
@@OH_OA_Synonyms.sql
@@OH_BSN_Synonyms.sql
@@OH_WEB_Synonyms.sql
@@MAPINFO_PRF_Synonyms.sql
@@MAPINFO_INF_Synonyms.sql
@@MAPINFO_OH_Synonyms.sql
@@MAPINFO_MAPINFO_Synonyms.sql
@@MAPINFO_DS_Synonyms.sql
@@MAPINFO_OA_Synonyms.sql
@@MAPINFO_BSN_Synonyms.sql
@@MAPINFO_WEB_Synonyms.sql
@@DS_PRF_Synonyms.sql
@@DS_INF_Synonyms.sql
@@DS_OH_Synonyms.sql
@@DS_MAPINFO_Synonyms.sql
@@DS_DS_Synonyms.sql
@@DS_OA_Synonyms.sql
@@DS_BSN_Synonyms.sql
@@DS_WEB_Synonyms.sql
@@OA_PRF_Synonyms.sql
@@OA_INF_Synonyms.sql
@@OA_OH_Synonyms.sql
@@OA_MAPINFO_Synonyms.sql
@@OA_DS_Synonyms.sql
@@OA_OA_Synonyms.sql
@@OA_BSN_Synonyms.sql
@@OA_WEB_Synonyms.sql
@@BSN_PRF_Synonyms.sql
@@BSN_INF_Synonyms.sql
@@BSN_OH_Synonyms.sql
@@BSN_MAPINFO_Synonyms.sql
@@BSN_DS_Synonyms.sql
@@BSN_OA_Synonyms.sql
@@BSN_BSN_Synonyms.sql
@@BSN_WEB_Synonyms.sql
@@WEB_PRF_Synonyms.sql
@@WEB_INF_Synonyms.sql
@@WEB_OH_Synonyms.sql
@@WEB_MAPINFO_Synonyms.sql
@@WEB_DS_Synonyms.sql
@@WEB_OA_Synonyms.sql
@@WEB_BSN_Synonyms.sql
@@WEB_WEB_Synonyms.sql

-- Droits des utilisateurs
@@PRF_Grants.sql
@@INF_Grants.sql
@@OH_Grants.sql
@@MAPINFO_Grants.sql
@@DS_Grants.sql
@@OA_Grants.sql
@@BSN_Grants.sql
@@WEB_Grants.sql

-- Script additionnels et recompilation des schemas 
@@SystemCompileSchemas.sql
disconnect

