/*################################################################################################*/
/* Script     : OA_Uks.sql                                                                        */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

ALTER TABLE CLS_OA
ADD CONSTRAINT CLS_OA_UK 
UNIQUE (TABLE_NAME,KEY_VALUE) 
USING INDEX
;

ALTER TABLE DOC_OA
ADD CONSTRAINT DOC_OA_UK 
UNIQUE (CD_DOC__CODE,REF) 
USING INDEX
;

