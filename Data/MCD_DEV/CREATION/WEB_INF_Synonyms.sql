/*################################################################################################*/
/* Script     : WEB_INF_Synonyms.sql                                                              */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

CREATE OR REPLACE  SYNONYM INF_ADMIN.SYS_INSTANCE_WEB FOR WEB.SYS_INSTANCE_WEB;
CREATE OR REPLACE  SYNONYM INF_VALID.SYS_INSTANCE_WEB FOR WEB.SYS_INSTANCE_WEB;
CREATE OR REPLACE  SYNONYM INF_CONSULT.SYS_INSTANCE_WEB FOR WEB.SYS_INSTANCE_WEB;
-- Synonym du role WEB_ADMIN pour le sch�ma INF
CREATE OR REPLACE SYNONYM WEB_ADMIN.ACCIDENT_INF FOR INF.ACCIDENT_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.AIRE_INF FOR INF.AIRE_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.PR_OLD_INF FOR INF.PR_OLD_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.BIFURCATION_INF FOR INF.BIFURCATION_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.BRETELLE_INF FOR INF.BRETELLE_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CHAUSSEE_INF FOR INF.CHAUSSEE_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_CLASS_TRAF_INF FOR INF.CD_CLASS_TRAF_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CLS_INF FOR INF.CLS_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CLIM_INF FOR INF.CLIM_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CLS_DOC_INF FOR INF.CLS_DOC_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_DEC_INF FOR INF.CD_DEC_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_POSIT_INF FOR INF.CD_POSIT_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_VOIE_INF FOR INF.CD_VOIE_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CONTACT_INF FOR INF.CONTACT_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CORRESPONDANCE_INF FOR INF.CORRESPONDANCE_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.DICTIONNAIRE_INF FOR INF.DICTIONNAIRE_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.DOC_INF FOR INF.DOC_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.ECLAIRAGE_INF FOR INF.ECLAIRAGE_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.EVT_INF FOR INF.EVT_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.FAM_DEC_INF FOR INF.FAM_DEC_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.WGS_INF FOR INF.WGS_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.GARE_INF FOR INF.GARE_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.LIAISON_INF FOR INF.LIAISON_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.OCCUPATION_INF FOR INF.OCCUPATION_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.DSC_OA_INF FOR INF.DSC_OA_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.PAVE_VOIE_INF FOR INF.PAVE_VOIE_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.PK_INF FOR INF.PK_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.AIRE__PLACE_INF FOR INF.AIRE__PLACE_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.PT_SING_INF FOR INF.PT_SING_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.REPERE_INF FOR INF.REPERE_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.PRESTATAIRE_INF FOR INF.PRESTATAIRE_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.AIRE__PRESTATAIRE_INF FOR INF.AIRE__PRESTATAIRE_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.PREV_SGE_INF FOR INF.PREV_SGE_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.AMENAGEMENT_INF FOR INF.AMENAGEMENT_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.REPARTITION_TRAFIC_INF FOR INF.REPARTITION_TRAFIC_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.SECTION_TRAFIC_INF FOR INF.SECTION_TRAFIC_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.SECURITE_INF FOR INF.SECURITE_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.AIRE__SERVICE_INF FOR INF.AIRE__SERVICE_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.SYS_USER_INF FOR INF.SYS_USER_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.TALUS_INF FOR INF.TALUS_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.TPC_INF FOR INF.TPC_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.TRAFIC_INF FOR INF.TRAFIC_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.TR_DEC_INF FOR INF.TR_DEC_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_AIRE_INF FOR INF.CD_AIRE_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_AMENAG_INF FOR INF.CD_AMENAG_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_BIF_INF FOR INF.CD_BIF_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_DOC_INF FOR INF.CD_DOC_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_EVT_INF FOR INF.CD_EVT_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_ECLAIR_INF FOR INF.CD_ECLAIR_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_GARE_INF FOR INF.CD_GARE_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_LIAISON_INF FOR INF.CD_LIAISON_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_OCCUPANT_INF FOR INF.CD_OCCUPANT_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_OCCUP_INF FOR INF.CD_OCCUP_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_PLACE_INF FOR INF.CD_PLACE_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_PT_SING_INF FOR INF.CD_PT_SING_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_PRESTATAIRE_INF FOR INF.CD_PRESTATAIRE_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_SECUR_INF FOR INF.CD_SECUR_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_SERVICE_INF FOR INF.CD_SERVICE_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_TALUS_INF FOR INF.CD_TALUS_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_TPC_INF FOR INF.CD_TPC_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_CLIM_INF FOR INF.CD_CLIM_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_SENSIBLE_INF FOR INF.CD_SENSIBLE_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CL_VOIE_INF FOR INF.CL_VOIE_INF;
CREATE OR REPLACE SYNONYM WEB_ADMIN.SENSIBLE_INF FOR INF.SENSIBLE_INF;
CREATE OR REPLACE  SYNONYM WEB_ADMIN.PR_TO_ABS FOR INF.PR_TO_ABS;
CREATE OR REPLACE  SYNONYM WEB_ADMIN.ABS_TO_PR FOR INF.ABS_TO_PR;
CREATE OR REPLACE  SYNONYM WEB_ADMIN.ABS_TO_WGS FOR INF.ABS_TO_WGS;
CREATE OR REPLACE  SYNONYM WEB_ADMIN.WGS_TO_NUM_OUVRAGES FOR INF.WGS_TO_NUM_OUVRAGES;
CREATE OR REPLACE  SYNONYM WEB_ADMIN.ABS_TO_WGS_LINE FOR INF.ABS_TO_WGS_LINE;
CREATE OR REPLACE  SYNONYM WEB_ADMIN.GET_DECOUPAGE FOR INF.GET_DECOUPAGE;
CREATE OR REPLACE  SYNONYM WEB_ADMIN.WGS_DISTANCE FOR INF.WGS_DISTANCE;
CREATE OR REPLACE  SYNONYM WEB_ADMIN.ST_ASGEOJSON FOR INF.ST_ASGEOJSON;
CREATE OR REPLACE  SYNONYM WEB_ADMIN.SYS_PRP_INF FOR INF.SYS_PRP_INF;
CREATE OR REPLACE  SYNONYM WEB_ADMIN.SEQ_CLS_INF FOR INF.SEQ_CLS_INF;
CREATE OR REPLACE  SYNONYM WEB_ADMIN.SEQ_DOC_INF FOR INF.SEQ_DOC_INF;
-- Synonym du role WEB_CONSULT pour le sch�ma INF
CREATE OR REPLACE SYNONYM WEB_CONSULT.ACCIDENT_INF FOR INF.ACCIDENT_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.AIRE_INF FOR INF.AIRE_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.PR_OLD_INF FOR INF.PR_OLD_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.BIFURCATION_INF FOR INF.BIFURCATION_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.BRETELLE_INF FOR INF.BRETELLE_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CHAUSSEE_INF FOR INF.CHAUSSEE_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_CLASS_TRAF_INF FOR INF.CD_CLASS_TRAF_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CLS_INF FOR INF.CLS_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CLIM_INF FOR INF.CLIM_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CLS_DOC_INF FOR INF.CLS_DOC_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_DEC_INF FOR INF.CD_DEC_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_POSIT_INF FOR INF.CD_POSIT_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_VOIE_INF FOR INF.CD_VOIE_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CONTACT_INF FOR INF.CONTACT_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CORRESPONDANCE_INF FOR INF.CORRESPONDANCE_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.DICTIONNAIRE_INF FOR INF.DICTIONNAIRE_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.DOC_INF FOR INF.DOC_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.ECLAIRAGE_INF FOR INF.ECLAIRAGE_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.EVT_INF FOR INF.EVT_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.FAM_DEC_INF FOR INF.FAM_DEC_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.WGS_INF FOR INF.WGS_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.GARE_INF FOR INF.GARE_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.LIAISON_INF FOR INF.LIAISON_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.OCCUPATION_INF FOR INF.OCCUPATION_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.DSC_OA_INF FOR INF.DSC_OA_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.PAVE_VOIE_INF FOR INF.PAVE_VOIE_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.PK_INF FOR INF.PK_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.AIRE__PLACE_INF FOR INF.AIRE__PLACE_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.PT_SING_INF FOR INF.PT_SING_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.REPERE_INF FOR INF.REPERE_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.PRESTATAIRE_INF FOR INF.PRESTATAIRE_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.AIRE__PRESTATAIRE_INF FOR INF.AIRE__PRESTATAIRE_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.PREV_SGE_INF FOR INF.PREV_SGE_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.AMENAGEMENT_INF FOR INF.AMENAGEMENT_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.REPARTITION_TRAFIC_INF FOR INF.REPARTITION_TRAFIC_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.SECTION_TRAFIC_INF FOR INF.SECTION_TRAFIC_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.SECURITE_INF FOR INF.SECURITE_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.AIRE__SERVICE_INF FOR INF.AIRE__SERVICE_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.SYS_USER_INF FOR INF.SYS_USER_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.TALUS_INF FOR INF.TALUS_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.TPC_INF FOR INF.TPC_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.TRAFIC_INF FOR INF.TRAFIC_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.TR_DEC_INF FOR INF.TR_DEC_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_AIRE_INF FOR INF.CD_AIRE_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_AMENAG_INF FOR INF.CD_AMENAG_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_BIF_INF FOR INF.CD_BIF_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_DOC_INF FOR INF.CD_DOC_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_EVT_INF FOR INF.CD_EVT_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_ECLAIR_INF FOR INF.CD_ECLAIR_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_GARE_INF FOR INF.CD_GARE_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_LIAISON_INF FOR INF.CD_LIAISON_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_OCCUPANT_INF FOR INF.CD_OCCUPANT_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_OCCUP_INF FOR INF.CD_OCCUP_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_PLACE_INF FOR INF.CD_PLACE_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_PT_SING_INF FOR INF.CD_PT_SING_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_PRESTATAIRE_INF FOR INF.CD_PRESTATAIRE_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_SECUR_INF FOR INF.CD_SECUR_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_SERVICE_INF FOR INF.CD_SERVICE_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_TALUS_INF FOR INF.CD_TALUS_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_TPC_INF FOR INF.CD_TPC_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_CLIM_INF FOR INF.CD_CLIM_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_SENSIBLE_INF FOR INF.CD_SENSIBLE_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CL_VOIE_INF FOR INF.CL_VOIE_INF;
CREATE OR REPLACE SYNONYM WEB_CONSULT.SENSIBLE_INF FOR INF.SENSIBLE_INF;
CREATE OR REPLACE  SYNONYM WEB_CONSULT.PR_TO_ABS FOR INF.PR_TO_ABS;
CREATE OR REPLACE  SYNONYM WEB_CONSULT.ABS_TO_PR FOR INF.ABS_TO_PR;
CREATE OR REPLACE  SYNONYM WEB_CONSULT.ABS_TO_WGS FOR INF.ABS_TO_WGS;
CREATE OR REPLACE  SYNONYM WEB_CONSULT.WGS_TO_NUM_OUVRAGES FOR INF.WGS_TO_NUM_OUVRAGES;
CREATE OR REPLACE  SYNONYM WEB_CONSULT.ABS_TO_WGS_LINE FOR INF.ABS_TO_WGS_LINE;
CREATE OR REPLACE  SYNONYM WEB_CONSULT.GET_DECOUPAGE FOR INF.GET_DECOUPAGE;
CREATE OR REPLACE  SYNONYM WEB_CONSULT.WGS_DISTANCE FOR INF.WGS_DISTANCE;
CREATE OR REPLACE  SYNONYM WEB_CONSULT.ST_ASGEOJSON FOR INF.ST_ASGEOJSON;
CREATE OR REPLACE  SYNONYM WEB_CONSULT.SYS_PRP_INF FOR INF.SYS_PRP_INF;
CREATE OR REPLACE  SYNONYM WEB_CONSULT.SEQ_CLS_INF FOR INF.SEQ_CLS_INF;
CREATE OR REPLACE  SYNONYM WEB_CONSULT.SEQ_DOC_INF FOR INF.SEQ_DOC_INF;
-- Synonym du role WEB_VALID pour le sch�ma INF
CREATE OR REPLACE SYNONYM WEB_VALID.ACCIDENT_INF FOR INF.ACCIDENT_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.AIRE_INF FOR INF.AIRE_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.PR_OLD_INF FOR INF.PR_OLD_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.BIFURCATION_INF FOR INF.BIFURCATION_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.BRETELLE_INF FOR INF.BRETELLE_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.CHAUSSEE_INF FOR INF.CHAUSSEE_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_CLASS_TRAF_INF FOR INF.CD_CLASS_TRAF_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.CLS_INF FOR INF.CLS_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.CLIM_INF FOR INF.CLIM_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.CLS_DOC_INF FOR INF.CLS_DOC_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_DEC_INF FOR INF.CD_DEC_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_POSIT_INF FOR INF.CD_POSIT_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_VOIE_INF FOR INF.CD_VOIE_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.CONTACT_INF FOR INF.CONTACT_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.CORRESPONDANCE_INF FOR INF.CORRESPONDANCE_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.DICTIONNAIRE_INF FOR INF.DICTIONNAIRE_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.DOC_INF FOR INF.DOC_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.ECLAIRAGE_INF FOR INF.ECLAIRAGE_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.EVT_INF FOR INF.EVT_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.FAM_DEC_INF FOR INF.FAM_DEC_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.WGS_INF FOR INF.WGS_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.GARE_INF FOR INF.GARE_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.LIAISON_INF FOR INF.LIAISON_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.OCCUPATION_INF FOR INF.OCCUPATION_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.DSC_OA_INF FOR INF.DSC_OA_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.PAVE_VOIE_INF FOR INF.PAVE_VOIE_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.PK_INF FOR INF.PK_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.AIRE__PLACE_INF FOR INF.AIRE__PLACE_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.PT_SING_INF FOR INF.PT_SING_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.REPERE_INF FOR INF.REPERE_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.PRESTATAIRE_INF FOR INF.PRESTATAIRE_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.AIRE__PRESTATAIRE_INF FOR INF.AIRE__PRESTATAIRE_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.PREV_SGE_INF FOR INF.PREV_SGE_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.AMENAGEMENT_INF FOR INF.AMENAGEMENT_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.REPARTITION_TRAFIC_INF FOR INF.REPARTITION_TRAFIC_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.SECTION_TRAFIC_INF FOR INF.SECTION_TRAFIC_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.SECURITE_INF FOR INF.SECURITE_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.AIRE__SERVICE_INF FOR INF.AIRE__SERVICE_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.SYS_USER_INF FOR INF.SYS_USER_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.TALUS_INF FOR INF.TALUS_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.TPC_INF FOR INF.TPC_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.TRAFIC_INF FOR INF.TRAFIC_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.TR_DEC_INF FOR INF.TR_DEC_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_AIRE_INF FOR INF.CD_AIRE_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_AMENAG_INF FOR INF.CD_AMENAG_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_BIF_INF FOR INF.CD_BIF_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_DOC_INF FOR INF.CD_DOC_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_EVT_INF FOR INF.CD_EVT_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_ECLAIR_INF FOR INF.CD_ECLAIR_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_GARE_INF FOR INF.CD_GARE_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_LIAISON_INF FOR INF.CD_LIAISON_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_OCCUPANT_INF FOR INF.CD_OCCUPANT_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_OCCUP_INF FOR INF.CD_OCCUP_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_PLACE_INF FOR INF.CD_PLACE_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_PT_SING_INF FOR INF.CD_PT_SING_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_PRESTATAIRE_INF FOR INF.CD_PRESTATAIRE_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_SECUR_INF FOR INF.CD_SECUR_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_SERVICE_INF FOR INF.CD_SERVICE_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_TALUS_INF FOR INF.CD_TALUS_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_TPC_INF FOR INF.CD_TPC_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_CLIM_INF FOR INF.CD_CLIM_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_SENSIBLE_INF FOR INF.CD_SENSIBLE_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.CL_VOIE_INF FOR INF.CL_VOIE_INF;
CREATE OR REPLACE SYNONYM WEB_VALID.SENSIBLE_INF FOR INF.SENSIBLE_INF;
CREATE OR REPLACE  SYNONYM WEB_VALID.PR_TO_ABS FOR INF.PR_TO_ABS;
CREATE OR REPLACE  SYNONYM WEB_VALID.ABS_TO_PR FOR INF.ABS_TO_PR;
CREATE OR REPLACE  SYNONYM WEB_VALID.ABS_TO_WGS FOR INF.ABS_TO_WGS;
CREATE OR REPLACE  SYNONYM WEB_VALID.WGS_TO_NUM_OUVRAGES FOR INF.WGS_TO_NUM_OUVRAGES;
CREATE OR REPLACE  SYNONYM WEB_VALID.ABS_TO_WGS_LINE FOR INF.ABS_TO_WGS_LINE;
CREATE OR REPLACE  SYNONYM WEB_VALID.GET_DECOUPAGE FOR INF.GET_DECOUPAGE;
CREATE OR REPLACE  SYNONYM WEB_VALID.WGS_DISTANCE FOR INF.WGS_DISTANCE;
CREATE OR REPLACE  SYNONYM WEB_VALID.ST_ASGEOJSON FOR INF.ST_ASGEOJSON;
CREATE OR REPLACE  SYNONYM WEB_VALID.SYS_PRP_INF FOR INF.SYS_PRP_INF;
CREATE OR REPLACE  SYNONYM WEB_VALID.SEQ_CLS_INF FOR INF.SEQ_CLS_INF;
CREATE OR REPLACE  SYNONYM WEB_VALID.SEQ_DOC_INF FOR INF.SEQ_DOC_INF;