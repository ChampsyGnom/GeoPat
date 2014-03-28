/*################################################################################################*/
/* Script     : BSN_Uks.sql                                                                       */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

ALTER TABLE CLS_BSN
ADD CONSTRAINT CLS_BSN_UK 
UNIQUE (TABLE_NAME,KEY_VALUE) 
USING INDEX
;

ALTER TABLE DOC_BSN
ADD CONSTRAINT DOC_BSN_UK 
UNIQUE (CD_DOC__CODE,REF) 
USING INDEX
;

