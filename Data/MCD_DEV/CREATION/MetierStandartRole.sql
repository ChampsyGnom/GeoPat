/*################################################################################################*/
/* Script     : MetierStandartRole.sql                                                            */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

CREATE ROLE schema_def ;
GRANT create procedure TO schema_def ;
GRANT create sequence  TO schema_def ;
GRANT create table     TO schema_def ;
GRANT create trigger   TO schema_def ;
GRANT create view      TO schema_def ;
