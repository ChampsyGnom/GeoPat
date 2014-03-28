/*################################################################################################*/
/* Script     : INF_Uks.sql                                                                       */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

ALTER TABLE CLS_INF
ADD CONSTRAINT CLS_INF_UK 
UNIQUE (TABLE_NAME,KEY_VALUE) 
USING INDEX
;

ALTER TABLE DOC_INF
ADD CONSTRAINT DOC_INF_UK 
UNIQUE (CD_DOC__CODE,REF) 
USING INDEX
;

