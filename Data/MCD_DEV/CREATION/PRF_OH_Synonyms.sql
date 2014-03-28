/*################################################################################################*/
/* Script     : PRF_OH_Synonyms.sql                                                               */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

CREATE OR REPLACE  SYNONYM OH_ADMIN.SYS_INSTANCE_PRF FOR PRF.SYS_INSTANCE_PRF;
CREATE OR REPLACE  SYNONYM OH_VALID.SYS_INSTANCE_PRF FOR PRF.SYS_INSTANCE_PRF;
CREATE OR REPLACE  SYNONYM OH_CONSULT.SYS_INSTANCE_PRF FOR PRF.SYS_INSTANCE_PRF;
-- Synonym du role PRF_ADMIN pour le sch�ma OH
CREATE OR REPLACE SYNONYM PRF_ADMIN.BPU_OH FOR OH.BPU_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CAMP_OH FOR OH.CAMP_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_CHAPITRE_OH FOR OH.CD_CHAPITRE_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CLS_OH FOR OH.CLS_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_CONCLUSION_OH FOR OH.CD_CONCLUSION_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_QUALITE_OH FOR OH.CD_QUALITE_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_CONCLUSION__INSP_OH FOR OH.CD_CONCLUSION__INSP_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_CONCLUSION__INSP_TMP_OH FOR OH.CD_CONCLUSION__INSP_TMP_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CONTACT_OH FOR OH.CONTACT_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CLS_DOC_OH FOR OH.CLS_DOC_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_CONTRAINTE_OH FOR OH.CD_CONTRAINTE_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.ELT_INSP_OH FOR OH.ELT_INSP_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.ELT_INSP_TMP_OH FOR OH.ELT_INSP_TMP_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.SPRT_VST_OH FOR OH.SPRT_VST_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.DICTIONNAIRE_OH FOR OH.DICTIONNAIRE_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.DOC_OH FOR OH.DOC_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_EAU_OH FOR OH.CD_EAU_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_ECOUL_OH FOR OH.CD_ECOUL_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.ELT_OH FOR OH.ELT_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_ENTETE_OH FOR OH.CD_ENTETE_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_ENTP_OH FOR OH.CD_ENTP_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_ETUDE_OH FOR OH.CD_ETUDE_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.EVT_OH FOR OH.EVT_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_FAM_OH FOR OH.CD_FAM_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.GRP_OH FOR OH.GRP_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.HISTO_NOTE_OH FOR OH.HISTO_NOTE_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.DSC_CAMP_OH FOR OH.DSC_CAMP_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.INSPECTEUR_OH FOR OH.INSPECTEUR_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.INSP_OH FOR OH.INSP_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.INSP_TMP_OH FOR OH.INSP_TMP_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_LIGNE_OH FOR OH.CD_LIGNE_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_MO_OH FOR OH.CD_MO_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_MAT_OH FOR OH.CD_MAT_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_METEO_OH FOR OH.CD_METEO_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.NATURE_TRAV_OH FOR OH.NATURE_TRAV_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_NOM_EAU_OH FOR OH.CD_NOM_EAU_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_ORIGIN_OH FOR OH.CD_ORIGIN_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.DSC_OH FOR OH.DSC_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.DSC_TEMP_OH FOR OH.DSC_TEMP_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.PRT_OH FOR OH.PRT_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.PHOTO_INSP_OH FOR OH.PHOTO_INSP_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.PHOTO_INSP_TMP_OH FOR OH.PHOTO_INSP_TMP_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.PHOTO_ELT_INSP_OH FOR OH.PHOTO_ELT_INSP_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.PHOTO_ELT_INSP_TMP_OH FOR OH.PHOTO_ELT_INSP_TMP_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.PHOTO_SPRT_VST_OH FOR OH.PHOTO_SPRT_VST_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.PHOTO_VST_OH FOR OH.PHOTO_VST_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_PRECO__SPRT_VST_OH FOR OH.CD_PRECO__SPRT_VST_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_PRESTA_OH FOR OH.CD_PRESTA_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.PREVISION_OH FOR OH.PREVISION_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_PRO_AM_OH FOR OH.CD_PRO_AM_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_PRO_AV_OH FOR OH.CD_PRO_AV_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.ENTETE_OH FOR OH.ENTETE_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.SEUIL_QUALITE_OH FOR OH.SEUIL_QUALITE_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.SEUIL_URGENCE_OH FOR OH.SEUIL_URGENCE_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.SPRT_OH FOR OH.SPRT_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_SOUS_TYPE_OH FOR OH.CD_SOUS_TYPE_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.SYS_USER_OH FOR OH.SYS_USER_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.TRAVAUX_OH FOR OH.TRAVAUX_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_COMPOSANT_OH FOR OH.CD_COMPOSANT_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_DOC_OH FOR OH.CD_DOC_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_EVT_OH FOR OH.CD_EVT_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_EXT_OH FOR OH.CD_EXT_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_OUV_OH FOR OH.CD_OUV_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_TYPE_OH FOR OH.CD_TYPE_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_TYPE_PV_OH FOR OH.CD_TYPE_PV_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_TETE_AM_OH FOR OH.CD_TETE_AM_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_TETE_AV_OH FOR OH.CD_TETE_AV_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_TRAVAUX_OH FOR OH.CD_TRAVAUX_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.CD_UNITE_OH FOR OH.CD_UNITE_OH;
CREATE OR REPLACE SYNONYM PRF_ADMIN.VST_OH FOR OH.VST_OH;
CREATE OR REPLACE  SYNONYM PRF_ADMIN.V_TRAVAUX_OH FOR OH.V_TRAVAUX_OH;
CREATE OR REPLACE  SYNONYM PRF_ADMIN.V_DSC_OH FOR OH.V_DSC_OH;
CREATE OR REPLACE  SYNONYM PRF_ADMIN.V_HISTO_CAMP_OH FOR OH.V_HISTO_CAMP_OH;
CREATE OR REPLACE  SYNONYM PRF_ADMIN.V_PREVISION_OH FOR OH.V_PREVISION_OH;
CREATE OR REPLACE  SYNONYM PRF_ADMIN.V_DERN_NOTE_OH FOR OH.V_DERN_NOTE_OH;
CREATE OR REPLACE  SYNONYM PRF_ADMIN.V_DETAIL_INSP_OH FOR OH.V_DETAIL_INSP_OH;
CREATE OR REPLACE  SYNONYM PRF_ADMIN.V_HISTO_NOTE_OH FOR OH.V_HISTO_NOTE_OH;
CREATE OR REPLACE  SYNONYM PRF_ADMIN.V_ELT_INSP_OH FOR OH.V_ELT_INSP_OH;
CREATE OR REPLACE  SYNONYM PRF_ADMIN.SYS_PRP_OH FOR OH.SYS_PRP_OH;
CREATE OR REPLACE  SYNONYM PRF_ADMIN.SEQ_CLS_OH FOR OH.SEQ_CLS_OH;
CREATE OR REPLACE  SYNONYM PRF_ADMIN.SEQ_DOC_OH FOR OH.SEQ_DOC_OH;
-- Synonym du role PRF_CONSULT pour le sch�ma OH
CREATE OR REPLACE SYNONYM PRF_CONSULT.BPU_OH FOR OH.BPU_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CAMP_OH FOR OH.CAMP_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_CHAPITRE_OH FOR OH.CD_CHAPITRE_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CLS_OH FOR OH.CLS_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_CONCLUSION_OH FOR OH.CD_CONCLUSION_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_QUALITE_OH FOR OH.CD_QUALITE_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_CONCLUSION__INSP_OH FOR OH.CD_CONCLUSION__INSP_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_CONCLUSION__INSP_TMP_OH FOR OH.CD_CONCLUSION__INSP_TMP_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CONTACT_OH FOR OH.CONTACT_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CLS_DOC_OH FOR OH.CLS_DOC_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_CONTRAINTE_OH FOR OH.CD_CONTRAINTE_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.ELT_INSP_OH FOR OH.ELT_INSP_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.ELT_INSP_TMP_OH FOR OH.ELT_INSP_TMP_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.SPRT_VST_OH FOR OH.SPRT_VST_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.DICTIONNAIRE_OH FOR OH.DICTIONNAIRE_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.DOC_OH FOR OH.DOC_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_EAU_OH FOR OH.CD_EAU_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_ECOUL_OH FOR OH.CD_ECOUL_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.ELT_OH FOR OH.ELT_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_ENTETE_OH FOR OH.CD_ENTETE_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_ENTP_OH FOR OH.CD_ENTP_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_ETUDE_OH FOR OH.CD_ETUDE_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.EVT_OH FOR OH.EVT_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_FAM_OH FOR OH.CD_FAM_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.GRP_OH FOR OH.GRP_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.HISTO_NOTE_OH FOR OH.HISTO_NOTE_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.DSC_CAMP_OH FOR OH.DSC_CAMP_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.INSPECTEUR_OH FOR OH.INSPECTEUR_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.INSP_OH FOR OH.INSP_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.INSP_TMP_OH FOR OH.INSP_TMP_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_LIGNE_OH FOR OH.CD_LIGNE_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_MO_OH FOR OH.CD_MO_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_MAT_OH FOR OH.CD_MAT_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_METEO_OH FOR OH.CD_METEO_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.NATURE_TRAV_OH FOR OH.NATURE_TRAV_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_NOM_EAU_OH FOR OH.CD_NOM_EAU_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_ORIGIN_OH FOR OH.CD_ORIGIN_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.DSC_OH FOR OH.DSC_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.DSC_TEMP_OH FOR OH.DSC_TEMP_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.PRT_OH FOR OH.PRT_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.PHOTO_INSP_OH FOR OH.PHOTO_INSP_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.PHOTO_INSP_TMP_OH FOR OH.PHOTO_INSP_TMP_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.PHOTO_ELT_INSP_OH FOR OH.PHOTO_ELT_INSP_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.PHOTO_ELT_INSP_TMP_OH FOR OH.PHOTO_ELT_INSP_TMP_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.PHOTO_SPRT_VST_OH FOR OH.PHOTO_SPRT_VST_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.PHOTO_VST_OH FOR OH.PHOTO_VST_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_PRECO__SPRT_VST_OH FOR OH.CD_PRECO__SPRT_VST_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_PRESTA_OH FOR OH.CD_PRESTA_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.PREVISION_OH FOR OH.PREVISION_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_PRO_AM_OH FOR OH.CD_PRO_AM_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_PRO_AV_OH FOR OH.CD_PRO_AV_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.ENTETE_OH FOR OH.ENTETE_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.SEUIL_QUALITE_OH FOR OH.SEUIL_QUALITE_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.SEUIL_URGENCE_OH FOR OH.SEUIL_URGENCE_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.SPRT_OH FOR OH.SPRT_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_SOUS_TYPE_OH FOR OH.CD_SOUS_TYPE_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.SYS_USER_OH FOR OH.SYS_USER_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.TRAVAUX_OH FOR OH.TRAVAUX_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_COMPOSANT_OH FOR OH.CD_COMPOSANT_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_DOC_OH FOR OH.CD_DOC_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_EVT_OH FOR OH.CD_EVT_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_EXT_OH FOR OH.CD_EXT_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_OUV_OH FOR OH.CD_OUV_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_TYPE_OH FOR OH.CD_TYPE_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_TYPE_PV_OH FOR OH.CD_TYPE_PV_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_TETE_AM_OH FOR OH.CD_TETE_AM_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_TETE_AV_OH FOR OH.CD_TETE_AV_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_TRAVAUX_OH FOR OH.CD_TRAVAUX_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.CD_UNITE_OH FOR OH.CD_UNITE_OH;
CREATE OR REPLACE SYNONYM PRF_CONSULT.VST_OH FOR OH.VST_OH;
CREATE OR REPLACE  SYNONYM PRF_CONSULT.V_TRAVAUX_OH FOR OH.V_TRAVAUX_OH;
CREATE OR REPLACE  SYNONYM PRF_CONSULT.V_DSC_OH FOR OH.V_DSC_OH;
CREATE OR REPLACE  SYNONYM PRF_CONSULT.V_HISTO_CAMP_OH FOR OH.V_HISTO_CAMP_OH;
CREATE OR REPLACE  SYNONYM PRF_CONSULT.V_PREVISION_OH FOR OH.V_PREVISION_OH;
CREATE OR REPLACE  SYNONYM PRF_CONSULT.V_DERN_NOTE_OH FOR OH.V_DERN_NOTE_OH;
CREATE OR REPLACE  SYNONYM PRF_CONSULT.V_DETAIL_INSP_OH FOR OH.V_DETAIL_INSP_OH;
CREATE OR REPLACE  SYNONYM PRF_CONSULT.V_HISTO_NOTE_OH FOR OH.V_HISTO_NOTE_OH;
CREATE OR REPLACE  SYNONYM PRF_CONSULT.V_ELT_INSP_OH FOR OH.V_ELT_INSP_OH;
CREATE OR REPLACE  SYNONYM PRF_CONSULT.SYS_PRP_OH FOR OH.SYS_PRP_OH;
CREATE OR REPLACE  SYNONYM PRF_CONSULT.SEQ_CLS_OH FOR OH.SEQ_CLS_OH;
CREATE OR REPLACE  SYNONYM PRF_CONSULT.SEQ_DOC_OH FOR OH.SEQ_DOC_OH;
