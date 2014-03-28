/*################################################################################################*/
/* Script     : ClearGMS.sql                                                                      */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

connect sys/Emash21@MCDDEV as sysdba
DROP USER GMS_ADMIN CASCADE;
DROP USER GMS_VALID CASCADE;
DROP USER GMS_CONSULT CASCADE;
DROP USER GMS CASCADE;
DROP ROLE GMS_SELECT;
DROP ROLE GMS_UPDATE;
DROP ROLE GMS_EXECUTE;
DROP ROLE GMS_UPDATE_EXT;
disconnect
