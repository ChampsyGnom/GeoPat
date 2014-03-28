/*################################################################################################*/
/* Script     : OA_Grants.sql                                                                     */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

/* Droit du role EXEC */
/* Droit du role SELECT */
GRANT SELECT ON OA.APPUIS_OA TO OA_SELECT;
GRANT SELECT ON OA.ARCHIVE_3_OA TO OA_SELECT;
GRANT SELECT ON OA.BPU_OA TO OA_SELECT;
GRANT SELECT ON OA.CD_BE_OA TO OA_SELECT;
GRANT SELECT ON OA.CAMP_OA TO OA_SELECT;
GRANT SELECT ON OA.CD_PRECO__SPRT_VST_OA TO OA_SELECT;
GRANT SELECT ON OA.CD_CHAPITRE_OA TO OA_SELECT;
GRANT SELECT ON OA.CLS_OA TO OA_SELECT;
GRANT SELECT ON OA.CD_CONCLUSION_OA TO OA_SELECT;
GRANT SELECT ON OA.CD_IQOA_OA TO OA_SELECT;
GRANT SELECT ON OA.CD_QUALITE_OA TO OA_SELECT;
GRANT SELECT ON OA.CD_TECH_OA TO OA_SELECT;
GRANT SELECT ON OA.CD_CONCLUSION__INSP_OA TO OA_SELECT;
GRANT SELECT ON OA.CD_CONCLUSION__INSP_TMP_OA TO OA_SELECT;
GRANT SELECT ON OA.CONTACT_OA TO OA_SELECT;
GRANT SELECT ON OA.CLS_DOC_OA TO OA_SELECT;
GRANT SELECT ON OA.CD_CONTRAINTE_OA TO OA_SELECT;
GRANT SELECT ON OA.ELT_INSP_OA TO OA_SELECT;
GRANT SELECT ON OA.ELT_INSP_TMP_OA TO OA_SELECT;
GRANT SELECT ON OA.SPRT_VST_OA TO OA_SELECT;
GRANT SELECT ON OA.DICTIONNAIRE_OA TO OA_SELECT;
GRANT SELECT ON OA.DOC_OA TO OA_SELECT;
GRANT SELECT ON OA.DSC__ARCHIVE_3_OA TO OA_SELECT;
GRANT SELECT ON OA.ELT_OA TO OA_SELECT;
GRANT SELECT ON OA.CD_ENTETE_OA TO OA_SELECT;
GRANT SELECT ON OA.CD_ENTP_OA TO OA_SELECT;
GRANT SELECT ON OA.EQUIPEMENT_OA TO OA_SELECT;
GRANT SELECT ON OA.CD_ETUDE_OA TO OA_SELECT;
GRANT SELECT ON OA.EVT_OA TO OA_SELECT;
GRANT SELECT ON OA.CD_FAM_OA TO OA_SELECT;
GRANT SELECT ON OA.CD_FAM_APPUI_OA TO OA_SELECT;
GRANT SELECT ON OA.CD_GEST_OA TO OA_SELECT;
GRANT SELECT ON OA.GRP_OA TO OA_SELECT;
GRANT SELECT ON OA.CD_HIERARCHIE_OA TO OA_SELECT;
GRANT SELECT ON OA.HISTO_NOTE_OA TO OA_SELECT;
GRANT SELECT ON OA.DSC_CAMP_OA TO OA_SELECT;
GRANT SELECT ON OA.INSPECTEUR_OA TO OA_SELECT;
GRANT SELECT ON OA.INSP_OA TO OA_SELECT;
GRANT SELECT ON OA.INSP_TMP_OA TO OA_SELECT;
GRANT SELECT ON OA.JOINT_OA TO OA_SELECT;
GRANT SELECT ON OA.CD_LIGNE_OA TO OA_SELECT;
GRANT SELECT ON OA.CD_MO_OA TO OA_SELECT;
GRANT SELECT ON OA.CD_MAT_OA TO OA_SELECT;
GRANT SELECT ON OA.CD_METEO_OA TO OA_SELECT;
GRANT SELECT ON OA.NATURE_TRAV_OA TO OA_SELECT;
GRANT SELECT ON OA.CD_OCCUPANT_OA TO OA_SELECT;
GRANT SELECT ON OA.OCCUPATION_OA TO OA_SELECT;
GRANT SELECT ON OA.CD_ORIGIN_OA TO OA_SELECT;
GRANT SELECT ON OA.DSC_OA TO OA_SELECT;
GRANT SELECT ON OA.DSC_TEMP_OA TO OA_SELECT;
GRANT SELECT ON OA.PRT_OA TO OA_SELECT;
GRANT SELECT ON OA.PHOTO_INSP_OA TO OA_SELECT;
GRANT SELECT ON OA.PHOTO_INSP_TMP_OA TO OA_SELECT;
GRANT SELECT ON OA.PHOTO_VST_OA TO OA_SELECT;
GRANT SELECT ON OA.PHOTO_ELT_INSP_OA TO OA_SELECT;
GRANT SELECT ON OA.PHOTO_ELT_INSP_TMP_OA TO OA_SELECT;
GRANT SELECT ON OA.PHOTO_SPRT_VST_OA TO OA_SELECT;
GRANT SELECT ON OA.CD_PRESTA_OA TO OA_SELECT;
GRANT SELECT ON OA.PREVISION_OA TO OA_SELECT;
GRANT SELECT ON OA.ENTETE_OA TO OA_SELECT;
GRANT SELECT ON OA.SEUIL_URGENCE_OA TO OA_SELECT;
GRANT SELECT ON OA.SPRT_OA TO OA_SELECT;
GRANT SELECT ON OA.SYS_USER_OA TO OA_SELECT;
GRANT SELECT ON OA.TABLIER_OA TO OA_SELECT;
GRANT SELECT ON OA.TRAVAUX_OA TO OA_SELECT;
GRANT SELECT ON OA.CD_COMPOSANT_OA TO OA_SELECT;
GRANT SELECT ON OA.CD_CHARGE_OA TO OA_SELECT;
GRANT SELECT ON OA.CD_EVT_OA TO OA_SELECT;
GRANT SELECT ON OA.CD_TYPE_OA TO OA_SELECT;
GRANT SELECT ON OA.CD_OCCUP_OA TO OA_SELECT;
GRANT SELECT ON OA.CD_TYPE_PV_OA TO OA_SELECT;
GRANT SELECT ON OA.CD_TRAVAUX_OA TO OA_SELECT;
GRANT SELECT ON OA.CD_APP_APPUI_OA TO OA_SELECT;
GRANT SELECT ON OA.CD_APPUI_OA TO OA_SELECT;
GRANT SELECT ON OA.CD_CHAPE_OA TO OA_SELECT;
GRANT SELECT ON OA.CD_DPR_OA TO OA_SELECT;
GRANT SELECT ON OA.CD_DOC_OA TO OA_SELECT;
GRANT SELECT ON OA.CD_FOND_OA TO OA_SELECT;
GRANT SELECT ON OA.CD_GC_OA TO OA_SELECT;
GRANT SELECT ON OA.CD_JOINT_OA TO OA_SELECT;
GRANT SELECT ON OA.CD_TABLIER_OA TO OA_SELECT;
GRANT SELECT ON OA.CD_UNITE_OA TO OA_SELECT;
GRANT SELECT ON OA.VST_OA TO OA_SELECT;
GRANT SELECT ON OA.V_TRAVAUX_OA TO OA_SELECT;
GRANT SELECT ON OA.V_DSC_OA TO OA_SELECT;
GRANT SELECT ON OA.V_HISTO_CAMP_OA TO OA_SELECT;
GRANT SELECT ON OA.V_PREVISION_OA TO OA_SELECT;
GRANT SELECT ON OA.V_DERN_NOTE_OA TO OA_SELECT;
GRANT SELECT ON OA.V_DETAIL_INSP_OA TO OA_SELECT;
GRANT SELECT ON OA.V_HISTO_NOTE_OA TO OA_SELECT;
GRANT SELECT ON OA.V_ELT_INSP_OA TO OA_SELECT;
GRANT SELECT ON OA.SEQ_CLS_OA TO OA_SELECT;
GRANT SELECT ON OA.SEQ_DOC_OA TO OA_SELECT;
GRANT SELECT ON OA.SYS_INSTANCE_OA TO OA_SELECT;
GRANT SELECT ON OA.SYS_PRP_OA TO OA_SELECT;
/* Droit du role UPDATE */
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.APPUIS_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.ARCHIVE_3_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.BPU_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CD_BE_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CAMP_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CD_PRECO__SPRT_VST_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CD_CHAPITRE_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CLS_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CD_CONCLUSION_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CD_IQOA_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CD_QUALITE_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CD_TECH_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CD_CONCLUSION__INSP_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CD_CONCLUSION__INSP_TMP_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CONTACT_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CLS_DOC_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CD_CONTRAINTE_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.ELT_INSP_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.ELT_INSP_TMP_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.SPRT_VST_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.DICTIONNAIRE_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.DOC_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.DSC__ARCHIVE_3_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.ELT_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CD_ENTETE_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CD_ENTP_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.EQUIPEMENT_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CD_ETUDE_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.EVT_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CD_FAM_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CD_FAM_APPUI_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CD_GEST_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.GRP_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CD_HIERARCHIE_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.HISTO_NOTE_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.DSC_CAMP_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.INSPECTEUR_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.INSP_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.INSP_TMP_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.JOINT_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CD_LIGNE_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CD_MO_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CD_MAT_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CD_METEO_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.NATURE_TRAV_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CD_OCCUPANT_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.OCCUPATION_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CD_ORIGIN_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.DSC_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.DSC_TEMP_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.PRT_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.PHOTO_INSP_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.PHOTO_INSP_TMP_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.PHOTO_VST_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.PHOTO_ELT_INSP_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.PHOTO_ELT_INSP_TMP_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.PHOTO_SPRT_VST_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CD_PRESTA_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.PREVISION_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.ENTETE_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.SEUIL_URGENCE_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.SPRT_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.SYS_USER_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.TABLIER_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.TRAVAUX_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CD_COMPOSANT_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CD_CHARGE_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CD_EVT_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CD_TYPE_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CD_OCCUP_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CD_TYPE_PV_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CD_TRAVAUX_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CD_APP_APPUI_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CD_APPUI_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CD_CHAPE_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CD_DPR_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CD_DOC_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CD_FOND_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CD_GC_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CD_JOINT_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CD_TABLIER_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.CD_UNITE_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.VST_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.SYS_INSTANCE_OA TO OA_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.SYS_PRP_OA TO OA_UPDATE;
/* Droit du role UPDATE_EXT */
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.DSC_OA TO OA_UPDATE_EXT;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.SYS_USER_OA TO OA_UPDATE_EXT;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.SYS_INSTANCE_OA TO OA_UPDATE_EXT;
GRANT SELECT,INSERT,UPDATE,DELETE ON OA.SYS_PRP_OA TO OA_UPDATE_EXT;