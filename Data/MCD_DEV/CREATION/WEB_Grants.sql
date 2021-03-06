/*################################################################################################*/
/* Script     : WEB_Grants.sql                                                                    */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

/* Droit du role EXEC */
/* Droit du role SELECT */
GRANT SELECT ON WEB.MODELE_WEB__NODE_WEB TO WEB_SELECT;
GRANT SELECT ON WEB.SYS_USER_WEB TO WEB_SELECT;
GRANT SELECT ON WEB.MODELE_WEB TO WEB_SELECT;
GRANT SELECT ON WEB.NODE_WEB TO WEB_SELECT;
GRANT SELECT ON WEB.NODE_PARAM_WEB TO WEB_SELECT;
GRANT SELECT ON WEB.STYLE_RULE_WEB TO WEB_SELECT;
GRANT SELECT ON WEB.STYLE_WEB TO WEB_SELECT;
GRANT SELECT ON WEB.NODE_WEB__STYLE_WEB TO WEB_SELECT;
GRANT SELECT ON WEB.CD_MODELE_WEB TO WEB_SELECT;
GRANT SELECT ON WEB.CD_NODE_WEB TO WEB_SELECT;
GRANT SELECT ON WEB.SEQ_NODE_WEB TO WEB_SELECT;
GRANT SELECT ON WEB.SEQ_STYLE_WEB TO WEB_SELECT;
GRANT SELECT ON WEB.SEQ_STYLE_RULE_WEB TO WEB_SELECT;
GRANT SELECT ON WEB.SEQ_MODELE_WEB TO WEB_SELECT;
GRANT SELECT ON WEB.SYS_INSTANCE_WEB TO WEB_SELECT;
GRANT SELECT ON WEB.SYS_PRP_WEB TO WEB_SELECT;
/* Droit du role UPDATE */
GRANT SELECT,INSERT,UPDATE,DELETE ON WEB.MODELE_WEB__NODE_WEB TO WEB_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON WEB.SYS_USER_WEB TO WEB_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON WEB.MODELE_WEB TO WEB_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON WEB.NODE_WEB TO WEB_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON WEB.NODE_PARAM_WEB TO WEB_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON WEB.STYLE_RULE_WEB TO WEB_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON WEB.STYLE_WEB TO WEB_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON WEB.NODE_WEB__STYLE_WEB TO WEB_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON WEB.CD_MODELE_WEB TO WEB_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON WEB.CD_NODE_WEB TO WEB_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON WEB.SYS_INSTANCE_WEB TO WEB_UPDATE;
GRANT SELECT,INSERT,UPDATE,DELETE ON WEB.SYS_PRP_WEB TO WEB_UPDATE;
/* Droit du role UPDATE_EXT */
GRANT SELECT,INSERT,UPDATE,DELETE ON WEB.SYS_INSTANCE_WEB TO WEB_UPDATE_EXT;
GRANT SELECT,INSERT,UPDATE,DELETE ON WEB.SYS_PRP_WEB TO WEB_UPDATE_EXT;
