/*################################################################################################*/
/* Script     : WEB_Users.sql                                                                     */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

-- Role Administrateur
CREATE USER WEB_ADMIN IDENTIFIED BY WEB_ADMIN 
DEFAULT TABLESPACE USERS
/
GRANT CONNECT TO WEB_ADMIN;
GRANT PRF_SELECT TO WEB_ADMIN;
GRANT PRF_EXECUTE TO WEB_ADMIN;
GRANT INF_SELECT TO WEB_ADMIN;
GRANT INF_EXECUTE TO WEB_ADMIN;
GRANT OH_SELECT TO WEB_ADMIN;
GRANT OH_EXECUTE TO WEB_ADMIN;
GRANT MAPINFO_SELECT TO WEB_ADMIN;
GRANT MAPINFO_EXECUTE TO WEB_ADMIN;
GRANT DS_SELECT TO WEB_ADMIN;
GRANT DS_EXECUTE TO WEB_ADMIN;
GRANT OA_SELECT TO WEB_ADMIN;
GRANT OA_EXECUTE TO WEB_ADMIN;
GRANT BSN_SELECT TO WEB_ADMIN;
GRANT BSN_EXECUTE TO WEB_ADMIN;
GRANT WEB_SELECT TO WEB_ADMIN;
GRANT WEB_EXECUTE TO WEB_ADMIN;
GRANT WEB_UPDATE TO WEB_ADMIN;
GRANT PRF_UPDATE_EXT TO WEB_ADMIN;
GRANT INF_UPDATE_EXT TO WEB_ADMIN;
GRANT OH_UPDATE_EXT TO WEB_ADMIN;
GRANT MAPINFO_UPDATE_EXT TO WEB_ADMIN;
GRANT DS_UPDATE_EXT TO WEB_ADMIN;
GRANT OA_UPDATE_EXT TO WEB_ADMIN;
GRANT BSN_UPDATE_EXT TO WEB_ADMIN;
GRANT WEB_UPDATE_EXT TO WEB_ADMIN;

-- Role Consultant
CREATE USER WEB_CONSULT IDENTIFIED BY WEB_CONSULT 
DEFAULT TABLESPACE USERS
/
GRANT CONNECT TO WEB_CONSULT;
GRANT PRF_SELECT TO WEB_CONSULT;
GRANT PRF_EXECUTE TO WEB_CONSULT;
GRANT INF_SELECT TO WEB_CONSULT;
GRANT INF_EXECUTE TO WEB_CONSULT;
GRANT OH_SELECT TO WEB_CONSULT;
GRANT OH_EXECUTE TO WEB_CONSULT;
GRANT MAPINFO_SELECT TO WEB_CONSULT;
GRANT MAPINFO_EXECUTE TO WEB_CONSULT;
GRANT DS_SELECT TO WEB_CONSULT;
GRANT DS_EXECUTE TO WEB_CONSULT;
GRANT OA_SELECT TO WEB_CONSULT;
GRANT OA_EXECUTE TO WEB_CONSULT;
GRANT BSN_SELECT TO WEB_CONSULT;
GRANT BSN_EXECUTE TO WEB_CONSULT;
GRANT WEB_SELECT TO WEB_CONSULT;
GRANT WEB_EXECUTE TO WEB_CONSULT;
GRANT PRF_UPDATE_EXT TO WEB_CONSULT;
GRANT INF_UPDATE_EXT TO WEB_CONSULT;
GRANT OH_UPDATE_EXT TO WEB_CONSULT;
GRANT MAPINFO_UPDATE_EXT TO WEB_CONSULT;
GRANT DS_UPDATE_EXT TO WEB_CONSULT;
GRANT OA_UPDATE_EXT TO WEB_CONSULT;
GRANT BSN_UPDATE_EXT TO WEB_CONSULT;
GRANT WEB_UPDATE_EXT TO WEB_CONSULT;

-- Role Valideur
CREATE USER WEB_VALID IDENTIFIED BY WEB_VALID 
DEFAULT TABLESPACE USERS
/
GRANT CONNECT TO WEB_VALID;
GRANT PRF_SELECT TO WEB_VALID;
GRANT PRF_EXECUTE TO WEB_VALID;
GRANT INF_SELECT TO WEB_VALID;
GRANT INF_EXECUTE TO WEB_VALID;
GRANT OH_SELECT TO WEB_VALID;
GRANT OH_EXECUTE TO WEB_VALID;
GRANT MAPINFO_SELECT TO WEB_VALID;
GRANT MAPINFO_EXECUTE TO WEB_VALID;
GRANT DS_SELECT TO WEB_VALID;
GRANT DS_EXECUTE TO WEB_VALID;
GRANT OA_SELECT TO WEB_VALID;
GRANT OA_EXECUTE TO WEB_VALID;
GRANT BSN_SELECT TO WEB_VALID;
GRANT BSN_EXECUTE TO WEB_VALID;
GRANT WEB_SELECT TO WEB_VALID;
GRANT WEB_EXECUTE TO WEB_VALID;
GRANT WEB_UPDATE TO WEB_VALID;
GRANT PRF_UPDATE_EXT TO WEB_VALID;
GRANT INF_UPDATE_EXT TO WEB_VALID;
GRANT OH_UPDATE_EXT TO WEB_VALID;
GRANT MAPINFO_UPDATE_EXT TO WEB_VALID;
GRANT DS_UPDATE_EXT TO WEB_VALID;
GRANT OA_UPDATE_EXT TO WEB_VALID;
GRANT BSN_UPDATE_EXT TO WEB_VALID;
GRANT WEB_UPDATE_EXT TO WEB_VALID;

