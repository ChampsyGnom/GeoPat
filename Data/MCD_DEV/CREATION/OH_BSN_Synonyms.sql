/*################################################################################################*/
/* Script     : OH_BSN_Synonyms.sql                                                               */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

CREATE OR REPLACE  SYNONYM BSN_ADMIN.SYS_INSTANCE_OH FOR OH.SYS_INSTANCE_OH;
CREATE OR REPLACE  SYNONYM BSN_VALID.SYS_INSTANCE_OH FOR OH.SYS_INSTANCE_OH;
CREATE OR REPLACE  SYNONYM BSN_CONSULT.SYS_INSTANCE_OH FOR OH.SYS_INSTANCE_OH;
-- Synonym du role OH_ADMIN pour le sch�ma BSN
CREATE OR REPLACE SYNONYM OH_ADMIN.DSC_BSN FOR BSN.DSC_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.DSC_TEMP_BSN FOR BSN.DSC_TEMP_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.BPU_BSN FOR BSN.BPU_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.CAMP_BSN FOR BSN.CAMP_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.CD_CHAPITRE_BSN FOR BSN.CD_CHAPITRE_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.CLS_BSN FOR BSN.CLS_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.CD_CONCLUSION_BSN FOR BSN.CD_CONCLUSION_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.CD_QUALITE_BSN FOR BSN.CD_QUALITE_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.CD_CONCLUSION__INSP_BSN FOR BSN.CD_CONCLUSION__INSP_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.CD_CONCLUSION__INSP_TMP_BSN FOR BSN.CD_CONCLUSION__INSP_TMP_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.CONTACT_BSN FOR BSN.CONTACT_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.CLS_DOC_BSN FOR BSN.CLS_DOC_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.CD_CONTRAINTE_BSN FOR BSN.CD_CONTRAINTE_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.EQUIPEMENT_BSN FOR BSN.EQUIPEMENT_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.ELT_INSP_BSN FOR BSN.ELT_INSP_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.ELT_INSP_TMP_BSN FOR BSN.ELT_INSP_TMP_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.SPRT_VST_BSN FOR BSN.SPRT_VST_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.DICTIONNAIRE_BSN FOR BSN.DICTIONNAIRE_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.CD_FREQUENCE_BSN FOR BSN.CD_FREQUENCE_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.DOC_BSN FOR BSN.DOC_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.ELT_BSN FOR BSN.ELT_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.CD_ENTETE_BSN FOR BSN.CD_ENTETE_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.CD_ENTP_BSN FOR BSN.CD_ENTP_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.CD_ETUDE_BSN FOR BSN.CD_ETUDE_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.EVT_BSN FOR BSN.EVT_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.CD_EXT_BSN FOR BSN.CD_EXT_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.CD_FAM_BSN FOR BSN.CD_FAM_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.CD_FAMEQP_BSN FOR BSN.CD_FAMEQP_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.GEOMETRIE_BSN FOR BSN.GEOMETRIE_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.GRP_BSN FOR BSN.GRP_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.HISTO_NOTE_BSN FOR BSN.HISTO_NOTE_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.DSC_CAMP_BSN FOR BSN.DSC_CAMP_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.IMPLUVIUM_BSN FOR BSN.IMPLUVIUM_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.INSPECTEUR_BSN FOR BSN.INSPECTEUR_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.INSP_BSN FOR BSN.INSP_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.INSP_TMP_BSN FOR BSN.INSP_TMP_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.CD_LIGNE_BSN FOR BSN.CD_LIGNE_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.CD_METEO_BSN FOR BSN.CD_METEO_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.CD_SOUS_TYPE_BSN FOR BSN.CD_SOUS_TYPE_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.NATURE_TRAV_BSN FOR BSN.NATURE_TRAV_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.CD_ORIGIN_BSN FOR BSN.CD_ORIGIN_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.PRT_BSN FOR BSN.PRT_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.CD_PERMEABLE_BSN FOR BSN.CD_PERMEABLE_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.PHOTO_INSP_BSN FOR BSN.PHOTO_INSP_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.PHOTO_INSP_TMP_BSN FOR BSN.PHOTO_INSP_TMP_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.PHOTO_ELT_INSP_BSN FOR BSN.PHOTO_ELT_INSP_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.PHOTO_ELT_INSP_TMP_BSN FOR BSN.PHOTO_ELT_INSP_TMP_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.PHOTO_SPRT_VST_BSN FOR BSN.PHOTO_SPRT_VST_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.PHOTO_VST_BSN FOR BSN.PHOTO_VST_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.CD_PRECO__SPRT_VST_BSN FOR BSN.CD_PRECO__SPRT_VST_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.CD_PRESTA_BSN FOR BSN.CD_PRESTA_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.PREVISION_BSN FOR BSN.PREVISION_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.CD_ROLE_BSN FOR BSN.CD_ROLE_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.CD_ROLE__DSC_BSN FOR BSN.CD_ROLE__DSC_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.ENTETE_BSN FOR BSN.ENTETE_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.CD_TYPE_BSN FOR BSN.CD_TYPE_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.SEUIL_QUALITE_BSN FOR BSN.SEUIL_QUALITE_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.SEUIL_URGENCE_BSN FOR BSN.SEUIL_URGENCE_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.SPRT_BSN FOR BSN.SPRT_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.SYS_USER_BSN FOR BSN.SYS_USER_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.TRAVAUX_BSN FOR BSN.TRAVAUX_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.CD_ACCES_BSN FOR BSN.CD_ACCES_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.CD_COMPOSANT_BSN FOR BSN.CD_COMPOSANT_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.CD_DOC_BSN FOR BSN.CD_DOC_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.CD_EVT_BSN FOR BSN.CD_EVT_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.CD_TYPEQP_BSN FOR BSN.CD_TYPEQP_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.CD_TYPE_PV_BSN FOR BSN.CD_TYPE_PV_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.CD_TRAVAUX_BSN FOR BSN.CD_TRAVAUX_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.CD_UNITE_BSN FOR BSN.CD_UNITE_BSN;
CREATE OR REPLACE SYNONYM OH_ADMIN.VST_BSN FOR BSN.VST_BSN;
CREATE OR REPLACE  SYNONYM OH_ADMIN.V_TRAVAUX_BSN FOR BSN.V_TRAVAUX_BSN;
CREATE OR REPLACE  SYNONYM OH_ADMIN.V_EQUIPEMENT_BSN FOR BSN.V_EQUIPEMENT_BSN;
CREATE OR REPLACE  SYNONYM OH_ADMIN.V_DSC_BSN FOR BSN.V_DSC_BSN;
CREATE OR REPLACE  SYNONYM OH_ADMIN.V_HISTO_CAMP_BSN FOR BSN.V_HISTO_CAMP_BSN;
CREATE OR REPLACE  SYNONYM OH_ADMIN.V_IMPLUVIUM_BSN FOR BSN.V_IMPLUVIUM_BSN;
CREATE OR REPLACE  SYNONYM OH_ADMIN.V_PREVISION_BSN FOR BSN.V_PREVISION_BSN;
CREATE OR REPLACE  SYNONYM OH_ADMIN.V_GEOMETRIE_BSN FOR BSN.V_GEOMETRIE_BSN;
CREATE OR REPLACE  SYNONYM OH_ADMIN.V_DERN_NOTE_BSN FOR BSN.V_DERN_NOTE_BSN;
CREATE OR REPLACE  SYNONYM OH_ADMIN.V_DETAIL_INSP_BSN FOR BSN.V_DETAIL_INSP_BSN;
CREATE OR REPLACE  SYNONYM OH_ADMIN.V_HISTO_NOTE_BSN FOR BSN.V_HISTO_NOTE_BSN;
CREATE OR REPLACE  SYNONYM OH_ADMIN.V_ELT_INSP_BSN FOR BSN.V_ELT_INSP_BSN;
CREATE OR REPLACE  SYNONYM OH_ADMIN.SYS_PRP_BSN FOR BSN.SYS_PRP_BSN;
CREATE OR REPLACE  SYNONYM OH_ADMIN.SEQ_CLS_BSN FOR BSN.SEQ_CLS_BSN;
CREATE OR REPLACE  SYNONYM OH_ADMIN.SEQ_DOC_BSN FOR BSN.SEQ_DOC_BSN;
-- Synonym du role OH_CONSULT pour le sch�ma BSN
CREATE OR REPLACE SYNONYM OH_CONSULT.DSC_BSN FOR BSN.DSC_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.DSC_TEMP_BSN FOR BSN.DSC_TEMP_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.BPU_BSN FOR BSN.BPU_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.CAMP_BSN FOR BSN.CAMP_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.CD_CHAPITRE_BSN FOR BSN.CD_CHAPITRE_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.CLS_BSN FOR BSN.CLS_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.CD_CONCLUSION_BSN FOR BSN.CD_CONCLUSION_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.CD_QUALITE_BSN FOR BSN.CD_QUALITE_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.CD_CONCLUSION__INSP_BSN FOR BSN.CD_CONCLUSION__INSP_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.CD_CONCLUSION__INSP_TMP_BSN FOR BSN.CD_CONCLUSION__INSP_TMP_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.CONTACT_BSN FOR BSN.CONTACT_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.CLS_DOC_BSN FOR BSN.CLS_DOC_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.CD_CONTRAINTE_BSN FOR BSN.CD_CONTRAINTE_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.EQUIPEMENT_BSN FOR BSN.EQUIPEMENT_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.ELT_INSP_BSN FOR BSN.ELT_INSP_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.ELT_INSP_TMP_BSN FOR BSN.ELT_INSP_TMP_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.SPRT_VST_BSN FOR BSN.SPRT_VST_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.DICTIONNAIRE_BSN FOR BSN.DICTIONNAIRE_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.CD_FREQUENCE_BSN FOR BSN.CD_FREQUENCE_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.DOC_BSN FOR BSN.DOC_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.ELT_BSN FOR BSN.ELT_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.CD_ENTETE_BSN FOR BSN.CD_ENTETE_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.CD_ENTP_BSN FOR BSN.CD_ENTP_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.CD_ETUDE_BSN FOR BSN.CD_ETUDE_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.EVT_BSN FOR BSN.EVT_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.CD_EXT_BSN FOR BSN.CD_EXT_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.CD_FAM_BSN FOR BSN.CD_FAM_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.CD_FAMEQP_BSN FOR BSN.CD_FAMEQP_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.GEOMETRIE_BSN FOR BSN.GEOMETRIE_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.GRP_BSN FOR BSN.GRP_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.HISTO_NOTE_BSN FOR BSN.HISTO_NOTE_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.DSC_CAMP_BSN FOR BSN.DSC_CAMP_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.IMPLUVIUM_BSN FOR BSN.IMPLUVIUM_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.INSPECTEUR_BSN FOR BSN.INSPECTEUR_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.INSP_BSN FOR BSN.INSP_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.INSP_TMP_BSN FOR BSN.INSP_TMP_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.CD_LIGNE_BSN FOR BSN.CD_LIGNE_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.CD_METEO_BSN FOR BSN.CD_METEO_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.CD_SOUS_TYPE_BSN FOR BSN.CD_SOUS_TYPE_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.NATURE_TRAV_BSN FOR BSN.NATURE_TRAV_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.CD_ORIGIN_BSN FOR BSN.CD_ORIGIN_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.PRT_BSN FOR BSN.PRT_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.CD_PERMEABLE_BSN FOR BSN.CD_PERMEABLE_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.PHOTO_INSP_BSN FOR BSN.PHOTO_INSP_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.PHOTO_INSP_TMP_BSN FOR BSN.PHOTO_INSP_TMP_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.PHOTO_ELT_INSP_BSN FOR BSN.PHOTO_ELT_INSP_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.PHOTO_ELT_INSP_TMP_BSN FOR BSN.PHOTO_ELT_INSP_TMP_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.PHOTO_SPRT_VST_BSN FOR BSN.PHOTO_SPRT_VST_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.PHOTO_VST_BSN FOR BSN.PHOTO_VST_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.CD_PRECO__SPRT_VST_BSN FOR BSN.CD_PRECO__SPRT_VST_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.CD_PRESTA_BSN FOR BSN.CD_PRESTA_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.PREVISION_BSN FOR BSN.PREVISION_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.CD_ROLE_BSN FOR BSN.CD_ROLE_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.CD_ROLE__DSC_BSN FOR BSN.CD_ROLE__DSC_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.ENTETE_BSN FOR BSN.ENTETE_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.CD_TYPE_BSN FOR BSN.CD_TYPE_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.SEUIL_QUALITE_BSN FOR BSN.SEUIL_QUALITE_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.SEUIL_URGENCE_BSN FOR BSN.SEUIL_URGENCE_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.SPRT_BSN FOR BSN.SPRT_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.SYS_USER_BSN FOR BSN.SYS_USER_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.TRAVAUX_BSN FOR BSN.TRAVAUX_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.CD_ACCES_BSN FOR BSN.CD_ACCES_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.CD_COMPOSANT_BSN FOR BSN.CD_COMPOSANT_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.CD_DOC_BSN FOR BSN.CD_DOC_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.CD_EVT_BSN FOR BSN.CD_EVT_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.CD_TYPEQP_BSN FOR BSN.CD_TYPEQP_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.CD_TYPE_PV_BSN FOR BSN.CD_TYPE_PV_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.CD_TRAVAUX_BSN FOR BSN.CD_TRAVAUX_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.CD_UNITE_BSN FOR BSN.CD_UNITE_BSN;
CREATE OR REPLACE SYNONYM OH_CONSULT.VST_BSN FOR BSN.VST_BSN;
CREATE OR REPLACE  SYNONYM OH_CONSULT.V_TRAVAUX_BSN FOR BSN.V_TRAVAUX_BSN;
CREATE OR REPLACE  SYNONYM OH_CONSULT.V_EQUIPEMENT_BSN FOR BSN.V_EQUIPEMENT_BSN;
CREATE OR REPLACE  SYNONYM OH_CONSULT.V_DSC_BSN FOR BSN.V_DSC_BSN;
CREATE OR REPLACE  SYNONYM OH_CONSULT.V_HISTO_CAMP_BSN FOR BSN.V_HISTO_CAMP_BSN;
CREATE OR REPLACE  SYNONYM OH_CONSULT.V_IMPLUVIUM_BSN FOR BSN.V_IMPLUVIUM_BSN;
CREATE OR REPLACE  SYNONYM OH_CONSULT.V_PREVISION_BSN FOR BSN.V_PREVISION_BSN;
CREATE OR REPLACE  SYNONYM OH_CONSULT.V_GEOMETRIE_BSN FOR BSN.V_GEOMETRIE_BSN;
CREATE OR REPLACE  SYNONYM OH_CONSULT.V_DERN_NOTE_BSN FOR BSN.V_DERN_NOTE_BSN;
CREATE OR REPLACE  SYNONYM OH_CONSULT.V_DETAIL_INSP_BSN FOR BSN.V_DETAIL_INSP_BSN;
CREATE OR REPLACE  SYNONYM OH_CONSULT.V_HISTO_NOTE_BSN FOR BSN.V_HISTO_NOTE_BSN;
CREATE OR REPLACE  SYNONYM OH_CONSULT.V_ELT_INSP_BSN FOR BSN.V_ELT_INSP_BSN;
CREATE OR REPLACE  SYNONYM OH_CONSULT.SYS_PRP_BSN FOR BSN.SYS_PRP_BSN;
CREATE OR REPLACE  SYNONYM OH_CONSULT.SEQ_CLS_BSN FOR BSN.SEQ_CLS_BSN;
CREATE OR REPLACE  SYNONYM OH_CONSULT.SEQ_DOC_BSN FOR BSN.SEQ_DOC_BSN;
-- Synonym du role OH_VALID pour le sch�ma BSN
CREATE OR REPLACE SYNONYM OH_VALID.DSC_BSN FOR BSN.DSC_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.DSC_TEMP_BSN FOR BSN.DSC_TEMP_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.BPU_BSN FOR BSN.BPU_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.CAMP_BSN FOR BSN.CAMP_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.CD_CHAPITRE_BSN FOR BSN.CD_CHAPITRE_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.CLS_BSN FOR BSN.CLS_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.CD_CONCLUSION_BSN FOR BSN.CD_CONCLUSION_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.CD_QUALITE_BSN FOR BSN.CD_QUALITE_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.CD_CONCLUSION__INSP_BSN FOR BSN.CD_CONCLUSION__INSP_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.CD_CONCLUSION__INSP_TMP_BSN FOR BSN.CD_CONCLUSION__INSP_TMP_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.CONTACT_BSN FOR BSN.CONTACT_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.CLS_DOC_BSN FOR BSN.CLS_DOC_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.CD_CONTRAINTE_BSN FOR BSN.CD_CONTRAINTE_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.EQUIPEMENT_BSN FOR BSN.EQUIPEMENT_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.ELT_INSP_BSN FOR BSN.ELT_INSP_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.ELT_INSP_TMP_BSN FOR BSN.ELT_INSP_TMP_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.SPRT_VST_BSN FOR BSN.SPRT_VST_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.DICTIONNAIRE_BSN FOR BSN.DICTIONNAIRE_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.CD_FREQUENCE_BSN FOR BSN.CD_FREQUENCE_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.DOC_BSN FOR BSN.DOC_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.ELT_BSN FOR BSN.ELT_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.CD_ENTETE_BSN FOR BSN.CD_ENTETE_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.CD_ENTP_BSN FOR BSN.CD_ENTP_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.CD_ETUDE_BSN FOR BSN.CD_ETUDE_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.EVT_BSN FOR BSN.EVT_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.CD_EXT_BSN FOR BSN.CD_EXT_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.CD_FAM_BSN FOR BSN.CD_FAM_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.CD_FAMEQP_BSN FOR BSN.CD_FAMEQP_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.GEOMETRIE_BSN FOR BSN.GEOMETRIE_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.GRP_BSN FOR BSN.GRP_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.HISTO_NOTE_BSN FOR BSN.HISTO_NOTE_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.DSC_CAMP_BSN FOR BSN.DSC_CAMP_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.IMPLUVIUM_BSN FOR BSN.IMPLUVIUM_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.INSPECTEUR_BSN FOR BSN.INSPECTEUR_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.INSP_BSN FOR BSN.INSP_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.INSP_TMP_BSN FOR BSN.INSP_TMP_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.CD_LIGNE_BSN FOR BSN.CD_LIGNE_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.CD_METEO_BSN FOR BSN.CD_METEO_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.CD_SOUS_TYPE_BSN FOR BSN.CD_SOUS_TYPE_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.NATURE_TRAV_BSN FOR BSN.NATURE_TRAV_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.CD_ORIGIN_BSN FOR BSN.CD_ORIGIN_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.PRT_BSN FOR BSN.PRT_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.CD_PERMEABLE_BSN FOR BSN.CD_PERMEABLE_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.PHOTO_INSP_BSN FOR BSN.PHOTO_INSP_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.PHOTO_INSP_TMP_BSN FOR BSN.PHOTO_INSP_TMP_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.PHOTO_ELT_INSP_BSN FOR BSN.PHOTO_ELT_INSP_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.PHOTO_ELT_INSP_TMP_BSN FOR BSN.PHOTO_ELT_INSP_TMP_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.PHOTO_SPRT_VST_BSN FOR BSN.PHOTO_SPRT_VST_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.PHOTO_VST_BSN FOR BSN.PHOTO_VST_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.CD_PRECO__SPRT_VST_BSN FOR BSN.CD_PRECO__SPRT_VST_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.CD_PRESTA_BSN FOR BSN.CD_PRESTA_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.PREVISION_BSN FOR BSN.PREVISION_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.CD_ROLE_BSN FOR BSN.CD_ROLE_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.CD_ROLE__DSC_BSN FOR BSN.CD_ROLE__DSC_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.ENTETE_BSN FOR BSN.ENTETE_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.CD_TYPE_BSN FOR BSN.CD_TYPE_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.SEUIL_QUALITE_BSN FOR BSN.SEUIL_QUALITE_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.SEUIL_URGENCE_BSN FOR BSN.SEUIL_URGENCE_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.SPRT_BSN FOR BSN.SPRT_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.SYS_USER_BSN FOR BSN.SYS_USER_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.TRAVAUX_BSN FOR BSN.TRAVAUX_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.CD_ACCES_BSN FOR BSN.CD_ACCES_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.CD_COMPOSANT_BSN FOR BSN.CD_COMPOSANT_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.CD_DOC_BSN FOR BSN.CD_DOC_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.CD_EVT_BSN FOR BSN.CD_EVT_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.CD_TYPEQP_BSN FOR BSN.CD_TYPEQP_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.CD_TYPE_PV_BSN FOR BSN.CD_TYPE_PV_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.CD_TRAVAUX_BSN FOR BSN.CD_TRAVAUX_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.CD_UNITE_BSN FOR BSN.CD_UNITE_BSN;
CREATE OR REPLACE SYNONYM OH_VALID.VST_BSN FOR BSN.VST_BSN;
CREATE OR REPLACE  SYNONYM OH_VALID.V_TRAVAUX_BSN FOR BSN.V_TRAVAUX_BSN;
CREATE OR REPLACE  SYNONYM OH_VALID.V_EQUIPEMENT_BSN FOR BSN.V_EQUIPEMENT_BSN;
CREATE OR REPLACE  SYNONYM OH_VALID.V_DSC_BSN FOR BSN.V_DSC_BSN;
CREATE OR REPLACE  SYNONYM OH_VALID.V_HISTO_CAMP_BSN FOR BSN.V_HISTO_CAMP_BSN;
CREATE OR REPLACE  SYNONYM OH_VALID.V_IMPLUVIUM_BSN FOR BSN.V_IMPLUVIUM_BSN;
CREATE OR REPLACE  SYNONYM OH_VALID.V_PREVISION_BSN FOR BSN.V_PREVISION_BSN;
CREATE OR REPLACE  SYNONYM OH_VALID.V_GEOMETRIE_BSN FOR BSN.V_GEOMETRIE_BSN;
CREATE OR REPLACE  SYNONYM OH_VALID.V_DERN_NOTE_BSN FOR BSN.V_DERN_NOTE_BSN;
CREATE OR REPLACE  SYNONYM OH_VALID.V_DETAIL_INSP_BSN FOR BSN.V_DETAIL_INSP_BSN;
CREATE OR REPLACE  SYNONYM OH_VALID.V_HISTO_NOTE_BSN FOR BSN.V_HISTO_NOTE_BSN;
CREATE OR REPLACE  SYNONYM OH_VALID.V_ELT_INSP_BSN FOR BSN.V_ELT_INSP_BSN;
CREATE OR REPLACE  SYNONYM OH_VALID.SYS_PRP_BSN FOR BSN.SYS_PRP_BSN;
CREATE OR REPLACE  SYNONYM OH_VALID.SEQ_CLS_BSN FOR BSN.SEQ_CLS_BSN;
CREATE OR REPLACE  SYNONYM OH_VALID.SEQ_DOC_BSN FOR BSN.SEQ_DOC_BSN;
