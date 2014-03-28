/*################################################################################################*/
/* Script     : ClearINF.sql                                                                      */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

connect sys/Emash21@MCDDEV as sysdba
DROP USER INF_ADMIN CASCADE;
DROP USER INF_VALID CASCADE;
DROP USER INF_CONSULT CASCADE;
DROP USER INF CASCADE;
DROP ROLE INF_SELECT;
DROP ROLE INF_UPDATE;
DROP ROLE INF_EXECUTE;
DROP ROLE INF_UPDATE_EXT;
disconnect
