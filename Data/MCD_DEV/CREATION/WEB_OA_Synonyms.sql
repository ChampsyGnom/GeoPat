/*################################################################################################*/
/* Script     : WEB_OA_Synonyms.sql                                                               */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

CREATE OR REPLACE  SYNONYM OA_ADMIN.SYS_INSTANCE_WEB FOR WEB.SYS_INSTANCE_WEB;
CREATE OR REPLACE  SYNONYM OA_VALID.SYS_INSTANCE_WEB FOR WEB.SYS_INSTANCE_WEB;
CREATE OR REPLACE  SYNONYM OA_CONSULT.SYS_INSTANCE_WEB FOR WEB.SYS_INSTANCE_WEB;
-- Synonym du role WEB_ADMIN pour le sch�ma OA
CREATE OR REPLACE SYNONYM WEB_ADMIN.APPUIS_OA FOR OA.APPUIS_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.ARCHIVE_3_OA FOR OA.ARCHIVE_3_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.BPU_OA FOR OA.BPU_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_BE_OA FOR OA.CD_BE_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CAMP_OA FOR OA.CAMP_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_PRECO__SPRT_VST_OA FOR OA.CD_PRECO__SPRT_VST_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_CHAPITRE_OA FOR OA.CD_CHAPITRE_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CLS_OA FOR OA.CLS_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_CONCLUSION_OA FOR OA.CD_CONCLUSION_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_IQOA_OA FOR OA.CD_IQOA_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_QUALITE_OA FOR OA.CD_QUALITE_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_TECH_OA FOR OA.CD_TECH_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_CONCLUSION__INSP_OA FOR OA.CD_CONCLUSION__INSP_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_CONCLUSION__INSP_TMP_OA FOR OA.CD_CONCLUSION__INSP_TMP_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CONTACT_OA FOR OA.CONTACT_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CLS_DOC_OA FOR OA.CLS_DOC_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_CONTRAINTE_OA FOR OA.CD_CONTRAINTE_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.ELT_INSP_OA FOR OA.ELT_INSP_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.ELT_INSP_TMP_OA FOR OA.ELT_INSP_TMP_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.SPRT_VST_OA FOR OA.SPRT_VST_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.DICTIONNAIRE_OA FOR OA.DICTIONNAIRE_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.DOC_OA FOR OA.DOC_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.DSC__ARCHIVE_3_OA FOR OA.DSC__ARCHIVE_3_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.ELT_OA FOR OA.ELT_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_ENTETE_OA FOR OA.CD_ENTETE_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_ENTP_OA FOR OA.CD_ENTP_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.EQUIPEMENT_OA FOR OA.EQUIPEMENT_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_ETUDE_OA FOR OA.CD_ETUDE_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.EVT_OA FOR OA.EVT_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_FAM_OA FOR OA.CD_FAM_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_FAM_APPUI_OA FOR OA.CD_FAM_APPUI_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_GEST_OA FOR OA.CD_GEST_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.GRP_OA FOR OA.GRP_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_HIERARCHIE_OA FOR OA.CD_HIERARCHIE_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.HISTO_NOTE_OA FOR OA.HISTO_NOTE_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.DSC_CAMP_OA FOR OA.DSC_CAMP_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.INSPECTEUR_OA FOR OA.INSPECTEUR_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.INSP_OA FOR OA.INSP_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.INSP_TMP_OA FOR OA.INSP_TMP_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.JOINT_OA FOR OA.JOINT_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_LIGNE_OA FOR OA.CD_LIGNE_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_MO_OA FOR OA.CD_MO_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_MAT_OA FOR OA.CD_MAT_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_METEO_OA FOR OA.CD_METEO_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.NATURE_TRAV_OA FOR OA.NATURE_TRAV_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_OCCUPANT_OA FOR OA.CD_OCCUPANT_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.OCCUPATION_OA FOR OA.OCCUPATION_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_ORIGIN_OA FOR OA.CD_ORIGIN_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.DSC_OA FOR OA.DSC_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.DSC_TEMP_OA FOR OA.DSC_TEMP_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.PRT_OA FOR OA.PRT_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.PHOTO_INSP_OA FOR OA.PHOTO_INSP_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.PHOTO_INSP_TMP_OA FOR OA.PHOTO_INSP_TMP_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.PHOTO_VST_OA FOR OA.PHOTO_VST_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.PHOTO_ELT_INSP_OA FOR OA.PHOTO_ELT_INSP_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.PHOTO_ELT_INSP_TMP_OA FOR OA.PHOTO_ELT_INSP_TMP_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.PHOTO_SPRT_VST_OA FOR OA.PHOTO_SPRT_VST_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_PRESTA_OA FOR OA.CD_PRESTA_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.PREVISION_OA FOR OA.PREVISION_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.ENTETE_OA FOR OA.ENTETE_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.SEUIL_URGENCE_OA FOR OA.SEUIL_URGENCE_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.SPRT_OA FOR OA.SPRT_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.SYS_USER_OA FOR OA.SYS_USER_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.TABLIER_OA FOR OA.TABLIER_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.TRAVAUX_OA FOR OA.TRAVAUX_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_COMPOSANT_OA FOR OA.CD_COMPOSANT_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_CHARGE_OA FOR OA.CD_CHARGE_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_EVT_OA FOR OA.CD_EVT_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_TYPE_OA FOR OA.CD_TYPE_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_OCCUP_OA FOR OA.CD_OCCUP_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_TYPE_PV_OA FOR OA.CD_TYPE_PV_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_TRAVAUX_OA FOR OA.CD_TRAVAUX_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_APP_APPUI_OA FOR OA.CD_APP_APPUI_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_APPUI_OA FOR OA.CD_APPUI_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_CHAPE_OA FOR OA.CD_CHAPE_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_DPR_OA FOR OA.CD_DPR_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_DOC_OA FOR OA.CD_DOC_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_FOND_OA FOR OA.CD_FOND_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_GC_OA FOR OA.CD_GC_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_JOINT_OA FOR OA.CD_JOINT_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_TABLIER_OA FOR OA.CD_TABLIER_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.CD_UNITE_OA FOR OA.CD_UNITE_OA;
CREATE OR REPLACE SYNONYM WEB_ADMIN.VST_OA FOR OA.VST_OA;
CREATE OR REPLACE  SYNONYM WEB_ADMIN.V_TRAVAUX_OA FOR OA.V_TRAVAUX_OA;
CREATE OR REPLACE  SYNONYM WEB_ADMIN.V_DSC_OA FOR OA.V_DSC_OA;
CREATE OR REPLACE  SYNONYM WEB_ADMIN.V_HISTO_CAMP_OA FOR OA.V_HISTO_CAMP_OA;
CREATE OR REPLACE  SYNONYM WEB_ADMIN.V_PREVISION_OA FOR OA.V_PREVISION_OA;
CREATE OR REPLACE  SYNONYM WEB_ADMIN.V_DERN_NOTE_OA FOR OA.V_DERN_NOTE_OA;
CREATE OR REPLACE  SYNONYM WEB_ADMIN.V_DETAIL_INSP_OA FOR OA.V_DETAIL_INSP_OA;
CREATE OR REPLACE  SYNONYM WEB_ADMIN.V_HISTO_NOTE_OA FOR OA.V_HISTO_NOTE_OA;
CREATE OR REPLACE  SYNONYM WEB_ADMIN.V_ELT_INSP_OA FOR OA.V_ELT_INSP_OA;
CREATE OR REPLACE  SYNONYM WEB_ADMIN.SYS_PRP_OA FOR OA.SYS_PRP_OA;
CREATE OR REPLACE  SYNONYM WEB_ADMIN.SEQ_CLS_OA FOR OA.SEQ_CLS_OA;
CREATE OR REPLACE  SYNONYM WEB_ADMIN.SEQ_DOC_OA FOR OA.SEQ_DOC_OA;
-- Synonym du role WEB_CONSULT pour le sch�ma OA
CREATE OR REPLACE SYNONYM WEB_CONSULT.APPUIS_OA FOR OA.APPUIS_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.ARCHIVE_3_OA FOR OA.ARCHIVE_3_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.BPU_OA FOR OA.BPU_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_BE_OA FOR OA.CD_BE_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CAMP_OA FOR OA.CAMP_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_PRECO__SPRT_VST_OA FOR OA.CD_PRECO__SPRT_VST_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_CHAPITRE_OA FOR OA.CD_CHAPITRE_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CLS_OA FOR OA.CLS_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_CONCLUSION_OA FOR OA.CD_CONCLUSION_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_IQOA_OA FOR OA.CD_IQOA_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_QUALITE_OA FOR OA.CD_QUALITE_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_TECH_OA FOR OA.CD_TECH_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_CONCLUSION__INSP_OA FOR OA.CD_CONCLUSION__INSP_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_CONCLUSION__INSP_TMP_OA FOR OA.CD_CONCLUSION__INSP_TMP_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CONTACT_OA FOR OA.CONTACT_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CLS_DOC_OA FOR OA.CLS_DOC_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_CONTRAINTE_OA FOR OA.CD_CONTRAINTE_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.ELT_INSP_OA FOR OA.ELT_INSP_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.ELT_INSP_TMP_OA FOR OA.ELT_INSP_TMP_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.SPRT_VST_OA FOR OA.SPRT_VST_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.DICTIONNAIRE_OA FOR OA.DICTIONNAIRE_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.DOC_OA FOR OA.DOC_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.DSC__ARCHIVE_3_OA FOR OA.DSC__ARCHIVE_3_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.ELT_OA FOR OA.ELT_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_ENTETE_OA FOR OA.CD_ENTETE_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_ENTP_OA FOR OA.CD_ENTP_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.EQUIPEMENT_OA FOR OA.EQUIPEMENT_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_ETUDE_OA FOR OA.CD_ETUDE_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.EVT_OA FOR OA.EVT_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_FAM_OA FOR OA.CD_FAM_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_FAM_APPUI_OA FOR OA.CD_FAM_APPUI_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_GEST_OA FOR OA.CD_GEST_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.GRP_OA FOR OA.GRP_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_HIERARCHIE_OA FOR OA.CD_HIERARCHIE_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.HISTO_NOTE_OA FOR OA.HISTO_NOTE_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.DSC_CAMP_OA FOR OA.DSC_CAMP_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.INSPECTEUR_OA FOR OA.INSPECTEUR_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.INSP_OA FOR OA.INSP_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.INSP_TMP_OA FOR OA.INSP_TMP_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.JOINT_OA FOR OA.JOINT_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_LIGNE_OA FOR OA.CD_LIGNE_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_MO_OA FOR OA.CD_MO_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_MAT_OA FOR OA.CD_MAT_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_METEO_OA FOR OA.CD_METEO_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.NATURE_TRAV_OA FOR OA.NATURE_TRAV_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_OCCUPANT_OA FOR OA.CD_OCCUPANT_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.OCCUPATION_OA FOR OA.OCCUPATION_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_ORIGIN_OA FOR OA.CD_ORIGIN_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.DSC_OA FOR OA.DSC_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.DSC_TEMP_OA FOR OA.DSC_TEMP_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.PRT_OA FOR OA.PRT_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.PHOTO_INSP_OA FOR OA.PHOTO_INSP_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.PHOTO_INSP_TMP_OA FOR OA.PHOTO_INSP_TMP_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.PHOTO_VST_OA FOR OA.PHOTO_VST_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.PHOTO_ELT_INSP_OA FOR OA.PHOTO_ELT_INSP_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.PHOTO_ELT_INSP_TMP_OA FOR OA.PHOTO_ELT_INSP_TMP_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.PHOTO_SPRT_VST_OA FOR OA.PHOTO_SPRT_VST_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_PRESTA_OA FOR OA.CD_PRESTA_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.PREVISION_OA FOR OA.PREVISION_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.ENTETE_OA FOR OA.ENTETE_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.SEUIL_URGENCE_OA FOR OA.SEUIL_URGENCE_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.SPRT_OA FOR OA.SPRT_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.SYS_USER_OA FOR OA.SYS_USER_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.TABLIER_OA FOR OA.TABLIER_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.TRAVAUX_OA FOR OA.TRAVAUX_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_COMPOSANT_OA FOR OA.CD_COMPOSANT_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_CHARGE_OA FOR OA.CD_CHARGE_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_EVT_OA FOR OA.CD_EVT_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_TYPE_OA FOR OA.CD_TYPE_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_OCCUP_OA FOR OA.CD_OCCUP_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_TYPE_PV_OA FOR OA.CD_TYPE_PV_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_TRAVAUX_OA FOR OA.CD_TRAVAUX_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_APP_APPUI_OA FOR OA.CD_APP_APPUI_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_APPUI_OA FOR OA.CD_APPUI_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_CHAPE_OA FOR OA.CD_CHAPE_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_DPR_OA FOR OA.CD_DPR_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_DOC_OA FOR OA.CD_DOC_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_FOND_OA FOR OA.CD_FOND_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_GC_OA FOR OA.CD_GC_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_JOINT_OA FOR OA.CD_JOINT_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_TABLIER_OA FOR OA.CD_TABLIER_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.CD_UNITE_OA FOR OA.CD_UNITE_OA;
CREATE OR REPLACE SYNONYM WEB_CONSULT.VST_OA FOR OA.VST_OA;
CREATE OR REPLACE  SYNONYM WEB_CONSULT.V_TRAVAUX_OA FOR OA.V_TRAVAUX_OA;
CREATE OR REPLACE  SYNONYM WEB_CONSULT.V_DSC_OA FOR OA.V_DSC_OA;
CREATE OR REPLACE  SYNONYM WEB_CONSULT.V_HISTO_CAMP_OA FOR OA.V_HISTO_CAMP_OA;
CREATE OR REPLACE  SYNONYM WEB_CONSULT.V_PREVISION_OA FOR OA.V_PREVISION_OA;
CREATE OR REPLACE  SYNONYM WEB_CONSULT.V_DERN_NOTE_OA FOR OA.V_DERN_NOTE_OA;
CREATE OR REPLACE  SYNONYM WEB_CONSULT.V_DETAIL_INSP_OA FOR OA.V_DETAIL_INSP_OA;
CREATE OR REPLACE  SYNONYM WEB_CONSULT.V_HISTO_NOTE_OA FOR OA.V_HISTO_NOTE_OA;
CREATE OR REPLACE  SYNONYM WEB_CONSULT.V_ELT_INSP_OA FOR OA.V_ELT_INSP_OA;
CREATE OR REPLACE  SYNONYM WEB_CONSULT.SYS_PRP_OA FOR OA.SYS_PRP_OA;
CREATE OR REPLACE  SYNONYM WEB_CONSULT.SEQ_CLS_OA FOR OA.SEQ_CLS_OA;
CREATE OR REPLACE  SYNONYM WEB_CONSULT.SEQ_DOC_OA FOR OA.SEQ_DOC_OA;
-- Synonym du role WEB_VALID pour le sch�ma OA
CREATE OR REPLACE SYNONYM WEB_VALID.APPUIS_OA FOR OA.APPUIS_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.ARCHIVE_3_OA FOR OA.ARCHIVE_3_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.BPU_OA FOR OA.BPU_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_BE_OA FOR OA.CD_BE_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CAMP_OA FOR OA.CAMP_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_PRECO__SPRT_VST_OA FOR OA.CD_PRECO__SPRT_VST_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_CHAPITRE_OA FOR OA.CD_CHAPITRE_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CLS_OA FOR OA.CLS_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_CONCLUSION_OA FOR OA.CD_CONCLUSION_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_IQOA_OA FOR OA.CD_IQOA_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_QUALITE_OA FOR OA.CD_QUALITE_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_TECH_OA FOR OA.CD_TECH_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_CONCLUSION__INSP_OA FOR OA.CD_CONCLUSION__INSP_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_CONCLUSION__INSP_TMP_OA FOR OA.CD_CONCLUSION__INSP_TMP_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CONTACT_OA FOR OA.CONTACT_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CLS_DOC_OA FOR OA.CLS_DOC_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_CONTRAINTE_OA FOR OA.CD_CONTRAINTE_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.ELT_INSP_OA FOR OA.ELT_INSP_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.ELT_INSP_TMP_OA FOR OA.ELT_INSP_TMP_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.SPRT_VST_OA FOR OA.SPRT_VST_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.DICTIONNAIRE_OA FOR OA.DICTIONNAIRE_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.DOC_OA FOR OA.DOC_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.DSC__ARCHIVE_3_OA FOR OA.DSC__ARCHIVE_3_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.ELT_OA FOR OA.ELT_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_ENTETE_OA FOR OA.CD_ENTETE_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_ENTP_OA FOR OA.CD_ENTP_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.EQUIPEMENT_OA FOR OA.EQUIPEMENT_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_ETUDE_OA FOR OA.CD_ETUDE_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.EVT_OA FOR OA.EVT_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_FAM_OA FOR OA.CD_FAM_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_FAM_APPUI_OA FOR OA.CD_FAM_APPUI_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_GEST_OA FOR OA.CD_GEST_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.GRP_OA FOR OA.GRP_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_HIERARCHIE_OA FOR OA.CD_HIERARCHIE_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.HISTO_NOTE_OA FOR OA.HISTO_NOTE_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.DSC_CAMP_OA FOR OA.DSC_CAMP_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.INSPECTEUR_OA FOR OA.INSPECTEUR_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.INSP_OA FOR OA.INSP_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.INSP_TMP_OA FOR OA.INSP_TMP_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.JOINT_OA FOR OA.JOINT_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_LIGNE_OA FOR OA.CD_LIGNE_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_MO_OA FOR OA.CD_MO_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_MAT_OA FOR OA.CD_MAT_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_METEO_OA FOR OA.CD_METEO_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.NATURE_TRAV_OA FOR OA.NATURE_TRAV_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_OCCUPANT_OA FOR OA.CD_OCCUPANT_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.OCCUPATION_OA FOR OA.OCCUPATION_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_ORIGIN_OA FOR OA.CD_ORIGIN_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.DSC_OA FOR OA.DSC_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.DSC_TEMP_OA FOR OA.DSC_TEMP_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.PRT_OA FOR OA.PRT_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.PHOTO_INSP_OA FOR OA.PHOTO_INSP_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.PHOTO_INSP_TMP_OA FOR OA.PHOTO_INSP_TMP_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.PHOTO_VST_OA FOR OA.PHOTO_VST_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.PHOTO_ELT_INSP_OA FOR OA.PHOTO_ELT_INSP_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.PHOTO_ELT_INSP_TMP_OA FOR OA.PHOTO_ELT_INSP_TMP_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.PHOTO_SPRT_VST_OA FOR OA.PHOTO_SPRT_VST_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_PRESTA_OA FOR OA.CD_PRESTA_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.PREVISION_OA FOR OA.PREVISION_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.ENTETE_OA FOR OA.ENTETE_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.SEUIL_URGENCE_OA FOR OA.SEUIL_URGENCE_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.SPRT_OA FOR OA.SPRT_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.SYS_USER_OA FOR OA.SYS_USER_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.TABLIER_OA FOR OA.TABLIER_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.TRAVAUX_OA FOR OA.TRAVAUX_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_COMPOSANT_OA FOR OA.CD_COMPOSANT_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_CHARGE_OA FOR OA.CD_CHARGE_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_EVT_OA FOR OA.CD_EVT_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_TYPE_OA FOR OA.CD_TYPE_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_OCCUP_OA FOR OA.CD_OCCUP_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_TYPE_PV_OA FOR OA.CD_TYPE_PV_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_TRAVAUX_OA FOR OA.CD_TRAVAUX_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_APP_APPUI_OA FOR OA.CD_APP_APPUI_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_APPUI_OA FOR OA.CD_APPUI_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_CHAPE_OA FOR OA.CD_CHAPE_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_DPR_OA FOR OA.CD_DPR_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_DOC_OA FOR OA.CD_DOC_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_FOND_OA FOR OA.CD_FOND_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_GC_OA FOR OA.CD_GC_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_JOINT_OA FOR OA.CD_JOINT_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_TABLIER_OA FOR OA.CD_TABLIER_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.CD_UNITE_OA FOR OA.CD_UNITE_OA;
CREATE OR REPLACE SYNONYM WEB_VALID.VST_OA FOR OA.VST_OA;
CREATE OR REPLACE  SYNONYM WEB_VALID.V_TRAVAUX_OA FOR OA.V_TRAVAUX_OA;
CREATE OR REPLACE  SYNONYM WEB_VALID.V_DSC_OA FOR OA.V_DSC_OA;
CREATE OR REPLACE  SYNONYM WEB_VALID.V_HISTO_CAMP_OA FOR OA.V_HISTO_CAMP_OA;
CREATE OR REPLACE  SYNONYM WEB_VALID.V_PREVISION_OA FOR OA.V_PREVISION_OA;
CREATE OR REPLACE  SYNONYM WEB_VALID.V_DERN_NOTE_OA FOR OA.V_DERN_NOTE_OA;
CREATE OR REPLACE  SYNONYM WEB_VALID.V_DETAIL_INSP_OA FOR OA.V_DETAIL_INSP_OA;
CREATE OR REPLACE  SYNONYM WEB_VALID.V_HISTO_NOTE_OA FOR OA.V_HISTO_NOTE_OA;
CREATE OR REPLACE  SYNONYM WEB_VALID.V_ELT_INSP_OA FOR OA.V_ELT_INSP_OA;
CREATE OR REPLACE  SYNONYM WEB_VALID.SYS_PRP_OA FOR OA.SYS_PRP_OA;
CREATE OR REPLACE  SYNONYM WEB_VALID.SEQ_CLS_OA FOR OA.SEQ_CLS_OA;
CREATE OR REPLACE  SYNONYM WEB_VALID.SEQ_DOC_OA FOR OA.SEQ_DOC_OA;
