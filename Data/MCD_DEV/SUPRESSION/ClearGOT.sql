/*################################################################################################*/
/* Script     : ClearGOT.sql                                                                      */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

connect sys/Emash21@MCDDEV as sysdba
DROP USER GOT_ADMIN CASCADE;
DROP USER GOT_VALID CASCADE;
DROP USER GOT_CONSULT CASCADE;
DROP USER GOT CASCADE;
DROP ROLE GOT_SELECT;
DROP ROLE GOT_UPDATE;
DROP ROLE GOT_EXECUTE;
DROP ROLE GOT_UPDATE_EXT;
disconnect
