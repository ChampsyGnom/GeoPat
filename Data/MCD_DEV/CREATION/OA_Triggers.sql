/*################################################################################################*/
/* Script     : OA_Triggers.sql                                                                   */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

-- Declaration du package d'integrite
Create or replace package IntegrityPackage AS
  Procedure InitNestLevel;
  Function GetNestLevel return number;
  Procedure NextNestLevel;
  Procedure PreviousNestLevel;
End IntegrityPackage;
/

-- Definition du package d'integrite
Create or replace package body IntegrityPackage AS
  NestLevel number;
  -- Procédure initialisant le niveau d'imbrication des triggers
  Procedure InitNestLevel is
  Begin
    NestLevel := 0;
  End;

  -- Fonction retournant le niveau d'imbrication des triggers
  Function GetNestLevel return number is
  Begin
    If NestLevel Is Null Then
      NestLevel := 0;
    End if;
    Return(NestLevel);
  End;

  -- Procédure augmentant le niveau d'imbrication des triggers
  Procedure NextNestLevel is
  Begin
  If NestLevel Is Null Then
    NestLevel := 0;
   End if;
   NestLevel := NestLevel + 1;
  End;

  -- Procédure diminuant le niveau d'imbrication des triggers
  Procedure PreviousNestLevel is
  Begin
    NestLevel := NestLevel - 1;
  End;

End IntegrityPackage;
/


create or replace TRIGGER "OA"."TIB_APPUISOA" before insert
on OA.APPUIS_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.DSC_OA"
	cursor c1_appuis_oa(Vdsc_oa__num_oa varchar) is
		select 1 
		from OA.DSC_OA 
		where 
		NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_FAM_APPUI_OA"
	cursor c2_appuis_oa(Vcd_fam_appui_oa__fam_app varchar) is
		select 1 
		from OA.CD_FAM_APPUI_OA 
		where 
		FAM_APP = Vcd_fam_appui_oa__fam_app and Vcd_fam_appui_oa__fam_app is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_APPUI_OA"
	cursor c3_appuis_oa(Vcd_appui_oa__app varchar) is
		select 1 
		from OA.CD_APPUI_OA 
		where 
		APP = Vcd_appui_oa__app and Vcd_appui_oa__app is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_APP_APPUI_OA"
	cursor c4_appuis_oa(Vcd_app_appui_oa__appui varchar) is
		select 1 
		from OA.CD_APP_APPUI_OA 
		where 
		APPUI = Vcd_app_appui_oa__appui and Vcd_app_appui_oa__appui is not null;
begin

	
	--  Le parent "OA.DSC_OA" doit exister à la création d'un enfant dans "OA.APPUIS_OA"
	if :new.DSC_OA__NUM_OA is not null then 
		open c1_appuis_oa ( :new.DSC_OA__NUM_OA);
		fetch c1_appuis_oa into dummy;
		found := c1_appuis_oa%FOUND;
		close c1_appuis_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.DSC_OA". Impossible de créer un enfant dans "OA.APPUIS_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_FAM_APPUI_OA" doit exister à la création d'un enfant dans "OA.APPUIS_OA"
	if :new.CD_FAM_APPUI_OA__FAM_APP is not null then 
		open c2_appuis_oa ( :new.CD_FAM_APPUI_OA__FAM_APP);
		fetch c2_appuis_oa into dummy;
		found := c2_appuis_oa%FOUND;
		close c2_appuis_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_FAM_APPUI_OA". Impossible de créer un enfant dans "OA.APPUIS_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_APPUI_OA" doit exister à la création d'un enfant dans "OA.APPUIS_OA"
	if :new.CD_APPUI_OA__APP is not null then 
		open c3_appuis_oa ( :new.CD_APPUI_OA__APP);
		fetch c3_appuis_oa into dummy;
		found := c3_appuis_oa%FOUND;
		close c3_appuis_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_APPUI_OA". Impossible de créer un enfant dans "OA.APPUIS_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_APP_APPUI_OA" doit exister à la création d'un enfant dans "OA.APPUIS_OA"
	if :new.CD_APP_APPUI_OA__APPUI is not null then 
		open c4_appuis_oa ( :new.CD_APP_APPUI_OA__APPUI);
		fetch c4_appuis_oa into dummy;
		found := c4_appuis_oa%FOUND;
		close c4_appuis_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_APP_APPUI_OA". Impossible de créer un enfant dans "OA.APPUIS_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_APPUISOA" before update
on OA.APPUIS_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.DSC_OA"
	cursor c1_appuis_oa (Vdsc_oa__num_oa varchar) is
		select 1 
		from OA.DSC_OA 
		where 
		NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_FAM_APPUI_OA"
	cursor c2_appuis_oa (Vcd_fam_appui_oa__fam_app varchar) is
		select 1 
		from OA.CD_FAM_APPUI_OA 
		where 
		FAM_APP = Vcd_fam_appui_oa__fam_app and Vcd_fam_appui_oa__fam_app is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_APPUI_OA"
	cursor c3_appuis_oa (Vcd_appui_oa__app varchar) is
		select 1 
		from OA.CD_APPUI_OA 
		where 
		APP = Vcd_appui_oa__app and Vcd_appui_oa__app is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_APP_APPUI_OA"
	cursor c4_appuis_oa (Vcd_app_appui_oa__appui varchar) is
		select 1 
		from OA.CD_APP_APPUI_OA 
		where 
		APPUI = Vcd_app_appui_oa__appui and Vcd_app_appui_oa__appui is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.DSC_OA" doit exister à la création d'un enfant dans "OA.APPUIS_OA"
	if :new.DSC_OA__NUM_OA is not null and seq = 0 then 
		open c1_appuis_oa ( :new.DSC_OA__NUM_OA);
		fetch c1_appuis_oa into dummy;
		found := c1_appuis_oa%FOUND;
		close c1_appuis_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.DSC_OA". Impossible de modifier un enfant dans "OA.APPUIS_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_FAM_APPUI_OA" doit exister à la création d'un enfant dans "OA.APPUIS_OA"
	if :new.CD_FAM_APPUI_OA__FAM_APP is not null and seq = 0 then 
		open c2_appuis_oa ( :new.CD_FAM_APPUI_OA__FAM_APP);
		fetch c2_appuis_oa into dummy;
		found := c2_appuis_oa%FOUND;
		close c2_appuis_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_FAM_APPUI_OA". Impossible de modifier un enfant dans "OA.APPUIS_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_APPUI_OA" doit exister à la création d'un enfant dans "OA.APPUIS_OA"
	if :new.CD_APPUI_OA__APP is not null and seq = 0 then 
		open c3_appuis_oa ( :new.CD_APPUI_OA__APP);
		fetch c3_appuis_oa into dummy;
		found := c3_appuis_oa%FOUND;
		close c3_appuis_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_APPUI_OA". Impossible de modifier un enfant dans "OA.APPUIS_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_APP_APPUI_OA" doit exister à la création d'un enfant dans "OA.APPUIS_OA"
	if :new.CD_APP_APPUI_OA__APPUI is not null and seq = 0 then 
		open c4_appuis_oa ( :new.CD_APP_APPUI_OA__APPUI);
		fetch c4_appuis_oa into dummy;
		found := c4_appuis_oa%FOUND;
		close c4_appuis_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_APP_APPUI_OA". Impossible de modifier un enfant dans "OA.APPUIS_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUA_ARCHIVE3OA" after update
of DATE_CALC
on OA.ARCHIVE_3_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.ARCHIVE_3_OA" dans les enfants "OA.DSC__ARCHIVE_3_OA"
	if ((updating('DATE_CALC') and :old.DATE_CALC != :new.DATE_CALC)) then 
		update OA.DSC__ARCHIVE_3_OA
		set ARCHIVE_3_OA__DATE_CALC = :new.DATE_CALC  
		where ARCHIVE_3_OA__DATE_CALC = :old.DATE_CALC;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_ARCHIVE3OA" after delete
on OA.ARCHIVE_3_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.DSC__ARCHIVE_3_OA"
	delete OA.DSC__ARCHIVE_3_OA
	where ARCHIVE_3_OA__DATE_CALC = :old.DATE_CALC;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TIB_BPUOA" before insert
on OA.BPU_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_TRAVAUX_OA"
	cursor c1_bpu_oa(Vcd_travaux_oa__code varchar) is
		select 1 
		from OA.CD_TRAVAUX_OA 
		where 
		CODE = Vcd_travaux_oa__code and Vcd_travaux_oa__code is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_UNITE_OA"
	cursor c2_bpu_oa(Vcd_unite_oa__unite varchar) is
		select 1 
		from OA.CD_UNITE_OA 
		where 
		UNITE = Vcd_unite_oa__unite and Vcd_unite_oa__unite is not null;
begin

	
	--  Le parent "OA.CD_TRAVAUX_OA" doit exister à la création d'un enfant dans "OA.BPU_OA"
	if :new.CD_TRAVAUX_OA__CODE is not null then 
		open c1_bpu_oa ( :new.CD_TRAVAUX_OA__CODE);
		fetch c1_bpu_oa into dummy;
		found := c1_bpu_oa%FOUND;
		close c1_bpu_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_TRAVAUX_OA". Impossible de créer un enfant dans "OA.BPU_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_UNITE_OA" doit exister à la création d'un enfant dans "OA.BPU_OA"
	if :new.CD_UNITE_OA__UNITE is not null then 
		open c2_bpu_oa ( :new.CD_UNITE_OA__UNITE);
		fetch c2_bpu_oa into dummy;
		found := c2_bpu_oa%FOUND;
		close c2_bpu_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_UNITE_OA". Impossible de créer un enfant dans "OA.BPU_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_BPUOA" before update
on OA.BPU_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_TRAVAUX_OA"
	cursor c1_bpu_oa (Vcd_travaux_oa__code varchar) is
		select 1 
		from OA.CD_TRAVAUX_OA 
		where 
		CODE = Vcd_travaux_oa__code and Vcd_travaux_oa__code is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_UNITE_OA"
	cursor c2_bpu_oa (Vcd_unite_oa__unite varchar) is
		select 1 
		from OA.CD_UNITE_OA 
		where 
		UNITE = Vcd_unite_oa__unite and Vcd_unite_oa__unite is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.CD_TRAVAUX_OA" doit exister à la création d'un enfant dans "OA.BPU_OA"
	if :new.CD_TRAVAUX_OA__CODE is not null and seq = 0 then 
		open c1_bpu_oa ( :new.CD_TRAVAUX_OA__CODE);
		fetch c1_bpu_oa into dummy;
		found := c1_bpu_oa%FOUND;
		close c1_bpu_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_TRAVAUX_OA". Impossible de modifier un enfant dans "OA.BPU_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_UNITE_OA" doit exister à la création d'un enfant dans "OA.BPU_OA"
	if :new.CD_UNITE_OA__UNITE is not null and seq = 0 then 
		open c2_bpu_oa ( :new.CD_UNITE_OA__UNITE);
		fetch c2_bpu_oa into dummy;
		found := c2_bpu_oa%FOUND;
		close c2_bpu_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_UNITE_OA". Impossible de modifier un enfant dans "OA.BPU_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUA_BPUOA" after update
of ID_BPU
on OA.BPU_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.BPU_OA" dans les enfants "OA.PREVISION_OA"
	if ((updating('ID_BPU') and :old.ID_BPU != :new.ID_BPU)) then 
		update OA.PREVISION_OA
		set BPU_OA__ID_BPU = :new.ID_BPU  
		where BPU_OA__ID_BPU = :old.ID_BPU;
	end if;
	--  Modification du code du parent "OA.BPU_OA" dans les enfants "OA.CD_PRECO__SPRT_VST_OA"
	if ((updating('ID_BPU') and :old.ID_BPU != :new.ID_BPU)) then 
		update OA.CD_PRECO__SPRT_VST_OA
		set BPU_OA__ID_BPU = :new.ID_BPU  
		where BPU_OA__ID_BPU = :old.ID_BPU;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_BPUOA" after delete
on OA.BPU_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.PREVISION_OA"
	delete OA.PREVISION_OA
	where BPU_OA__ID_BPU = :old.ID_BPU;
	
	--  Suppression des enfants dans "OA.CD_PRECO__SPRT_VST_OA"
	delete OA.CD_PRECO__SPRT_VST_OA
	where BPU_OA__ID_BPU = :old.ID_BPU;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TUA_CDBEOA" after update
of BUREAU
on OA.CD_BE_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.CD_BE_OA" dans les enfants "OA.DSC_OA"
	if ((updating('BUREAU') and :old.BUREAU != :new.BUREAU)) then 
		update OA.DSC_OA
		set CD_BE_OA__BUREAU = :new.BUREAU  
		where CD_BE_OA__BUREAU = :old.BUREAU;
	end if;
	--  Modification du code du parent "OA.CD_BE_OA" dans les enfants "OA.DSC_TEMP_OA"
	if ((updating('BUREAU') and :old.BUREAU != :new.BUREAU)) then 
		update OA.DSC_TEMP_OA
		set CD_BE_OA__BUREAU = :new.BUREAU  
		where CD_BE_OA__BUREAU = :old.BUREAU;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_CDBEOA" after delete
on OA.CD_BE_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.DSC_OA"
	delete OA.DSC_OA
	where CD_BE_OA__BUREAU = :old.BUREAU;
	
	--  Suppression des enfants dans "OA.DSC_TEMP_OA"
	delete OA.DSC_TEMP_OA
	where CD_BE_OA__BUREAU = :old.BUREAU;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TIB_CAMPOA" before insert
on OA.CAMP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_PRESTA_OA"
	cursor c1_camp_oa(Vcd_presta_oa__prestataire varchar) is
		select 1 
		from OA.CD_PRESTA_OA 
		where 
		PRESTATAIRE = Vcd_presta_oa__prestataire and Vcd_presta_oa__prestataire is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_TYPE_PV_OA"
	cursor c2_camp_oa(Vcd_type_pv_oa__code varchar) is
		select 1 
		from OA.CD_TYPE_PV_OA 
		where 
		CODE = Vcd_type_pv_oa__code and Vcd_type_pv_oa__code is not null;
begin

	
	--  Le parent "OA.CD_PRESTA_OA" doit exister à la création d'un enfant dans "OA.CAMP_OA"
	if :new.CD_PRESTA_OA__PRESTATAIRE is not null then 
		open c1_camp_oa ( :new.CD_PRESTA_OA__PRESTATAIRE);
		fetch c1_camp_oa into dummy;
		found := c1_camp_oa%FOUND;
		close c1_camp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_PRESTA_OA". Impossible de créer un enfant dans "OA.CAMP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_TYPE_PV_OA" doit exister à la création d'un enfant dans "OA.CAMP_OA"
	if :new.CD_TYPE_PV_OA__CODE is not null then 
		open c2_camp_oa ( :new.CD_TYPE_PV_OA__CODE);
		fetch c2_camp_oa into dummy;
		found := c2_camp_oa%FOUND;
		close c2_camp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_TYPE_PV_OA". Impossible de créer un enfant dans "OA.CAMP_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_CAMPOA" before update
on OA.CAMP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_PRESTA_OA"
	cursor c1_camp_oa (Vcd_presta_oa__prestataire varchar) is
		select 1 
		from OA.CD_PRESTA_OA 
		where 
		PRESTATAIRE = Vcd_presta_oa__prestataire and Vcd_presta_oa__prestataire is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_TYPE_PV_OA"
	cursor c2_camp_oa (Vcd_type_pv_oa__code varchar) is
		select 1 
		from OA.CD_TYPE_PV_OA 
		where 
		CODE = Vcd_type_pv_oa__code and Vcd_type_pv_oa__code is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.CD_PRESTA_OA" doit exister à la création d'un enfant dans "OA.CAMP_OA"
	if :new.CD_PRESTA_OA__PRESTATAIRE is not null and seq = 0 then 
		open c1_camp_oa ( :new.CD_PRESTA_OA__PRESTATAIRE);
		fetch c1_camp_oa into dummy;
		found := c1_camp_oa%FOUND;
		close c1_camp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_PRESTA_OA". Impossible de modifier un enfant dans "OA.CAMP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_TYPE_PV_OA" doit exister à la création d'un enfant dans "OA.CAMP_OA"
	if :new.CD_TYPE_PV_OA__CODE is not null and seq = 0 then 
		open c2_camp_oa ( :new.CD_TYPE_PV_OA__CODE);
		fetch c2_camp_oa into dummy;
		found := c2_camp_oa%FOUND;
		close c2_camp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_TYPE_PV_OA". Impossible de modifier un enfant dans "OA.CAMP_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUA_CAMPOA" after update
of ID_CAMP
on OA.CAMP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.CAMP_OA" dans les enfants "OA.VST_OA"
	if ((updating('ID_CAMP') and :old.ID_CAMP != :new.ID_CAMP)) then 
		update OA.VST_OA
		set CAMP_OA__ID_CAMP = :new.ID_CAMP  
		where CAMP_OA__ID_CAMP = :old.ID_CAMP;
	end if;
	--  Modification du code du parent "OA.CAMP_OA" dans les enfants "OA.INSP_OA"
	if ((updating('ID_CAMP') and :old.ID_CAMP != :new.ID_CAMP)) then 
		update OA.INSP_OA
		set CAMP_OA__ID_CAMP = :new.ID_CAMP  
		where CAMP_OA__ID_CAMP = :old.ID_CAMP;
	end if;
	--  Modification du code du parent "OA.CAMP_OA" dans les enfants "OA.DSC_TEMP_OA"
	if ((updating('ID_CAMP') and :old.ID_CAMP != :new.ID_CAMP)) then 
		update OA.DSC_TEMP_OA
		set CAMP_OA__ID_CAMP = :new.ID_CAMP  
		where CAMP_OA__ID_CAMP = :old.ID_CAMP;
	end if;
	--  Modification du code du parent "OA.CAMP_OA" dans les enfants "OA.DSC_CAMP_OA"
	if ((updating('ID_CAMP') and :old.ID_CAMP != :new.ID_CAMP)) then 
		update OA.DSC_CAMP_OA
		set CAMP_OA__ID_CAMP = :new.ID_CAMP  
		where CAMP_OA__ID_CAMP = :old.ID_CAMP;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_CAMPOA" after delete
on OA.CAMP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.VST_OA"
	delete OA.VST_OA
	where CAMP_OA__ID_CAMP = :old.ID_CAMP;
	
	--  Suppression des enfants dans "OA.INSP_OA"
	delete OA.INSP_OA
	where CAMP_OA__ID_CAMP = :old.ID_CAMP;
	
	--  Suppression des enfants dans "OA.DSC_TEMP_OA"
	delete OA.DSC_TEMP_OA
	where CAMP_OA__ID_CAMP = :old.ID_CAMP;
	
	--  Suppression des enfants dans "OA.DSC_CAMP_OA"
	delete OA.DSC_CAMP_OA
	where CAMP_OA__ID_CAMP = :old.ID_CAMP;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TIB_CDPRECOSPRTVSTOA" before insert
on OA.CD_PRECO__SPRT_VST_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.VST_OA"
	cursor c1_cd_preco__sprt_vst_oa(Vdsc_oa__num_oa varchar,
	Vcamp_oa__id_camp varchar) is
		select 1 
		from OA.VST_OA 
		where 
		DSC_OA__NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null and 
		CAMP_OA__ID_CAMP = Vcamp_oa__id_camp and Vcamp_oa__id_camp is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.BPU_OA"
	cursor c2_cd_preco__sprt_vst_oa(Vbpu_oa__id_bpu number) is
		select 1 
		from OA.BPU_OA 
		where 
		ID_BPU = Vbpu_oa__id_bpu and Vbpu_oa__id_bpu is not null;
begin

	
	--  Le parent "OA.VST_OA" doit exister à la création d'un enfant dans "OA.CD_PRECO__SPRT_VST_OA"
	if :new.DSC_OA__NUM_OA is not null and 
	:new.CAMP_OA__ID_CAMP is not null then 
		open c1_cd_preco__sprt_vst_oa ( :new.DSC_OA__NUM_OA,
		:new.CAMP_OA__ID_CAMP);
		fetch c1_cd_preco__sprt_vst_oa into dummy;
		found := c1_cd_preco__sprt_vst_oa%FOUND;
		close c1_cd_preco__sprt_vst_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.VST_OA". Impossible de créer un enfant dans "OA.CD_PRECO__SPRT_VST_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.BPU_OA" doit exister à la création d'un enfant dans "OA.CD_PRECO__SPRT_VST_OA"
	if :new.BPU_OA__ID_BPU is not null then 
		open c2_cd_preco__sprt_vst_oa ( :new.BPU_OA__ID_BPU);
		fetch c2_cd_preco__sprt_vst_oa into dummy;
		found := c2_cd_preco__sprt_vst_oa%FOUND;
		close c2_cd_preco__sprt_vst_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.BPU_OA". Impossible de créer un enfant dans "OA.CD_PRECO__SPRT_VST_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_CDPRECOSPRTVSTOA" before update
on OA.CD_PRECO__SPRT_VST_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.VST_OA"
	cursor c1_cd_preco__sprt_vst_oa (Vdsc_oa__num_oa varchar,
	Vcamp_oa__id_camp varchar) is
		select 1 
		from OA.VST_OA 
		where 
		DSC_OA__NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null and 
		CAMP_OA__ID_CAMP = Vcamp_oa__id_camp and Vcamp_oa__id_camp is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.BPU_OA"
	cursor c2_cd_preco__sprt_vst_oa (Vbpu_oa__id_bpu number) is
		select 1 
		from OA.BPU_OA 
		where 
		ID_BPU = Vbpu_oa__id_bpu and Vbpu_oa__id_bpu is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.VST_OA" doit exister à la création d'un enfant dans "OA.CD_PRECO__SPRT_VST_OA"
	if :new.DSC_OA__NUM_OA is not null and seq = 0 and 
	:new.CAMP_OA__ID_CAMP is not null and seq = 0 then 
		open c1_cd_preco__sprt_vst_oa ( :new.DSC_OA__NUM_OA,
		:new.CAMP_OA__ID_CAMP);
		fetch c1_cd_preco__sprt_vst_oa into dummy;
		found := c1_cd_preco__sprt_vst_oa%FOUND;
		close c1_cd_preco__sprt_vst_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.VST_OA". Impossible de modifier un enfant dans "OA.CD_PRECO__SPRT_VST_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.BPU_OA" doit exister à la création d'un enfant dans "OA.CD_PRECO__SPRT_VST_OA"
	if :new.BPU_OA__ID_BPU is not null and seq = 0 then 
		open c2_cd_preco__sprt_vst_oa ( :new.BPU_OA__ID_BPU);
		fetch c2_cd_preco__sprt_vst_oa into dummy;
		found := c2_cd_preco__sprt_vst_oa%FOUND;
		close c2_cd_preco__sprt_vst_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.BPU_OA". Impossible de modifier un enfant dans "OA.CD_PRECO__SPRT_VST_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUA_CDCHAPITREOA" after update
of ID_CHAP
on OA.CD_CHAPITRE_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.CD_CHAPITRE_OA" dans les enfants "OA.CD_LIGNE_OA"
	if ((updating('ID_CHAP') and :old.ID_CHAP != :new.ID_CHAP)) then 
		update OA.CD_LIGNE_OA
		set CD_CHAPITRE_OA__ID_CHAP = :new.ID_CHAP  
		where CD_CHAPITRE_OA__ID_CHAP = :old.ID_CHAP;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_CDCHAPITREOA" after delete
on OA.CD_CHAPITRE_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.CD_LIGNE_OA"
	delete OA.CD_LIGNE_OA
	where CD_CHAPITRE_OA__ID_CHAP = :old.ID_CHAP;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TUA_CLSOA" after update
of ID
on OA.CLS_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.CLS_OA" dans les enfants "OA.CLS_DOC_OA"
	if ((updating('ID') and :old.ID != :new.ID)) then 
		update OA.CLS_DOC_OA
		set CLS__ID = :new.ID  
		where CLS__ID = :old.ID;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_CLSOA" after delete
on OA.CLS_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.CLS_DOC_OA"
	delete OA.CLS_DOC_OA
	where CLS__ID = :old.ID;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TUA_CDCONCLUSIONOA" after update
of ID_CONC
on OA.CD_CONCLUSION_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.CD_CONCLUSION_OA" dans les enfants "OA.CD_CONCLUSION__INSP_OA"
	if ((updating('ID_CONC') and :old.ID_CONC != :new.ID_CONC)) then 
		update OA.CD_CONCLUSION__INSP_OA
		set CD_CONCLUSION_OA__ID_CONC = :new.ID_CONC  
		where CD_CONCLUSION_OA__ID_CONC = :old.ID_CONC;
	end if;
	--  Modification du code du parent "OA.CD_CONCLUSION_OA" dans les enfants "OA.CD_CONCLUSION__INSP_TMP_OA"
	if ((updating('ID_CONC') and :old.ID_CONC != :new.ID_CONC)) then 
		update OA.CD_CONCLUSION__INSP_TMP_OA
		set CD_CONCLUSION_OA__ID_CONC = :new.ID_CONC  
		where CD_CONCLUSION_OA__ID_CONC = :old.ID_CONC;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_CDCONCLUSIONOA" after delete
on OA.CD_CONCLUSION_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.CD_CONCLUSION__INSP_OA"
	delete OA.CD_CONCLUSION__INSP_OA
	where CD_CONCLUSION_OA__ID_CONC = :old.ID_CONC;
	
	--  Suppression des enfants dans "OA.CD_CONCLUSION__INSP_TMP_OA"
	delete OA.CD_CONCLUSION__INSP_TMP_OA
	where CD_CONCLUSION_OA__ID_CONC = :old.ID_CONC;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TUA_CDIQOAOA" after update
of NOTE_IQOA
on OA.CD_IQOA_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.CD_IQOA_OA" dans les enfants "OA.INSP_OA"
	if ((updating('NOTE_IQOA') and :old.NOTE_IQOA != :new.NOTE_IQOA)) then 
		update OA.INSP_OA
		set CD_IQOA_OA__NOTE_IQOA = :new.NOTE_IQOA  
		where CD_IQOA_OA__NOTE_IQOA = :old.NOTE_IQOA;
	end if;
	--  Modification du code du parent "OA.CD_IQOA_OA" dans les enfants "OA.CD_QUALITE_OA"
	if ((updating('NOTE_IQOA') and :old.NOTE_IQOA != :new.NOTE_IQOA)) then 
		update OA.CD_QUALITE_OA
		set CD_IQOA_OA__NOTE_IQOA = :new.NOTE_IQOA  
		where CD_IQOA_OA__NOTE_IQOA = :old.NOTE_IQOA;
	end if;
	--  Modification du code du parent "OA.CD_IQOA_OA" dans les enfants "OA.INSP_TMP_OA"
	if ((updating('NOTE_IQOA') and :old.NOTE_IQOA != :new.NOTE_IQOA)) then 
		update OA.INSP_TMP_OA
		set CD_IQOA_OA__NOTE_IQOA = :new.NOTE_IQOA  
		where CD_IQOA_OA__NOTE_IQOA = :old.NOTE_IQOA;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_CDIQOAOA" after delete
on OA.CD_IQOA_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.INSP_OA"
	delete OA.INSP_OA
	where CD_IQOA_OA__NOTE_IQOA = :old.NOTE_IQOA;
	
	--  Suppression des enfants dans "OA.CD_QUALITE_OA"
	delete OA.CD_QUALITE_OA
	where CD_IQOA_OA__NOTE_IQOA = :old.NOTE_IQOA;
	
	--  Suppression des enfants dans "OA.INSP_TMP_OA"
	delete OA.INSP_TMP_OA
	where CD_IQOA_OA__NOTE_IQOA = :old.NOTE_IQOA;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TIB_CDQUALITEOA" before insert
on OA.CD_QUALITE_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_IQOA_OA"
	cursor c1_cd_qualite_oa(Vcd_iqoa_oa__note_iqoa varchar) is
		select 1 
		from OA.CD_IQOA_OA 
		where 
		NOTE_IQOA = Vcd_iqoa_oa__note_iqoa and Vcd_iqoa_oa__note_iqoa is not null;
begin

	
	--  Le parent "OA.CD_IQOA_OA" doit exister à la création d'un enfant dans "OA.CD_QUALITE_OA"
	if :new.CD_IQOA_OA__NOTE_IQOA is not null then 
		open c1_cd_qualite_oa ( :new.CD_IQOA_OA__NOTE_IQOA);
		fetch c1_cd_qualite_oa into dummy;
		found := c1_cd_qualite_oa%FOUND;
		close c1_cd_qualite_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_IQOA_OA". Impossible de créer un enfant dans "OA.CD_QUALITE_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_CDQUALITEOA" before update
on OA.CD_QUALITE_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_IQOA_OA"
	cursor c1_cd_qualite_oa (Vcd_iqoa_oa__note_iqoa varchar) is
		select 1 
		from OA.CD_IQOA_OA 
		where 
		NOTE_IQOA = Vcd_iqoa_oa__note_iqoa and Vcd_iqoa_oa__note_iqoa is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.CD_IQOA_OA" doit exister à la création d'un enfant dans "OA.CD_QUALITE_OA"
	if :new.CD_IQOA_OA__NOTE_IQOA is not null and seq = 0 then 
		open c1_cd_qualite_oa ( :new.CD_IQOA_OA__NOTE_IQOA);
		fetch c1_cd_qualite_oa into dummy;
		found := c1_cd_qualite_oa%FOUND;
		close c1_cd_qualite_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_IQOA_OA". Impossible de modifier un enfant dans "OA.CD_QUALITE_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUA_CDQUALITEOA" after update
of CD_IQOA_OA__NOTE_IQOA,QUALITE
on OA.CD_QUALITE_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.CD_QUALITE_OA" dans les enfants "OA.DSC_OA"
	if ((updating('CD_IQOA_OA__NOTE_IQOA') and :old.CD_IQOA_OA__NOTE_IQOA != :new.CD_IQOA_OA__NOTE_IQOA) or 
	(updating('QUALITE') and :old.QUALITE != :new.QUALITE)) then 
		update OA.DSC_OA
		set CD_IQOA_OA__NOTE_IQOA = :new.CD_IQOA_OA__NOTE_IQOA,
		CD_QUALITE_OA__QUALITE = :new.QUALITE  
		where CD_IQOA_OA__NOTE_IQOA = :old.CD_IQOA_OA__NOTE_IQOA and 
		CD_QUALITE_OA__QUALITE = :old.QUALITE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_CDQUALITEOA" after delete
on OA.CD_QUALITE_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.DSC_OA"
	delete OA.DSC_OA
	where CD_IQOA_OA__NOTE_IQOA = :old.CD_IQOA_OA__NOTE_IQOA and 
	CD_QUALITE_OA__QUALITE = :old.QUALITE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TUA_CDTECHOA" after update
of TECHNIQUE
on OA.CD_TECH_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.CD_TECH_OA" dans les enfants "OA.TABLIER_OA"
	if ((updating('TECHNIQUE') and :old.TECHNIQUE != :new.TECHNIQUE)) then 
		update OA.TABLIER_OA
		set CD_TECH_OA__TECHNIQUE = :new.TECHNIQUE  
		where CD_TECH_OA__TECHNIQUE = :old.TECHNIQUE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_CDTECHOA" after delete
on OA.CD_TECH_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.TABLIER_OA"
	delete OA.TABLIER_OA
	where CD_TECH_OA__TECHNIQUE = :old.TECHNIQUE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TIB_CDCONCLUSIONINSPOA" before insert
on OA.CD_CONCLUSION__INSP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_CONCLUSION_OA"
	cursor c1_cd_conclusion__insp_oa(Vcd_conclusion_oa__id_conc number) is
		select 1 
		from OA.CD_CONCLUSION_OA 
		where 
		ID_CONC = Vcd_conclusion_oa__id_conc and Vcd_conclusion_oa__id_conc is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.INSP_OA"
	cursor c2_cd_conclusion__insp_oa(Vdsc_oa__num_oa varchar,
	Vcamp_oa__id_camp varchar) is
		select 1 
		from OA.INSP_OA 
		where 
		DSC_OA__NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null and 
		CAMP_OA__ID_CAMP = Vcamp_oa__id_camp and Vcamp_oa__id_camp is not null;
begin

	
	--  Le parent "OA.CD_CONCLUSION_OA" doit exister à la création d'un enfant dans "OA.CD_CONCLUSION__INSP_OA"
	if :new.CD_CONCLUSION_OA__ID_CONC is not null then 
		open c1_cd_conclusion__insp_oa ( :new.CD_CONCLUSION_OA__ID_CONC);
		fetch c1_cd_conclusion__insp_oa into dummy;
		found := c1_cd_conclusion__insp_oa%FOUND;
		close c1_cd_conclusion__insp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_CONCLUSION_OA". Impossible de créer un enfant dans "OA.CD_CONCLUSION__INSP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.INSP_OA" doit exister à la création d'un enfant dans "OA.CD_CONCLUSION__INSP_OA"
	if :new.DSC_OA__NUM_OA is not null and 
	:new.CAMP_OA__ID_CAMP is not null then 
		open c2_cd_conclusion__insp_oa ( :new.DSC_OA__NUM_OA,
		:new.CAMP_OA__ID_CAMP);
		fetch c2_cd_conclusion__insp_oa into dummy;
		found := c2_cd_conclusion__insp_oa%FOUND;
		close c2_cd_conclusion__insp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.INSP_OA". Impossible de créer un enfant dans "OA.CD_CONCLUSION__INSP_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_CDCONCLUSIONINSPOA" before update
on OA.CD_CONCLUSION__INSP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_CONCLUSION_OA"
	cursor c1_cd_conclusion__insp_oa (Vcd_conclusion_oa__id_conc number) is
		select 1 
		from OA.CD_CONCLUSION_OA 
		where 
		ID_CONC = Vcd_conclusion_oa__id_conc and Vcd_conclusion_oa__id_conc is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.INSP_OA"
	cursor c2_cd_conclusion__insp_oa (Vdsc_oa__num_oa varchar,
	Vcamp_oa__id_camp varchar) is
		select 1 
		from OA.INSP_OA 
		where 
		DSC_OA__NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null and 
		CAMP_OA__ID_CAMP = Vcamp_oa__id_camp and Vcamp_oa__id_camp is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.CD_CONCLUSION_OA" doit exister à la création d'un enfant dans "OA.CD_CONCLUSION__INSP_OA"
	if :new.CD_CONCLUSION_OA__ID_CONC is not null and seq = 0 then 
		open c1_cd_conclusion__insp_oa ( :new.CD_CONCLUSION_OA__ID_CONC);
		fetch c1_cd_conclusion__insp_oa into dummy;
		found := c1_cd_conclusion__insp_oa%FOUND;
		close c1_cd_conclusion__insp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_CONCLUSION_OA". Impossible de modifier un enfant dans "OA.CD_CONCLUSION__INSP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.INSP_OA" doit exister à la création d'un enfant dans "OA.CD_CONCLUSION__INSP_OA"
	if :new.DSC_OA__NUM_OA is not null and seq = 0 and 
	:new.CAMP_OA__ID_CAMP is not null and seq = 0 then 
		open c2_cd_conclusion__insp_oa ( :new.DSC_OA__NUM_OA,
		:new.CAMP_OA__ID_CAMP);
		fetch c2_cd_conclusion__insp_oa into dummy;
		found := c2_cd_conclusion__insp_oa%FOUND;
		close c2_cd_conclusion__insp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.INSP_OA". Impossible de modifier un enfant dans "OA.CD_CONCLUSION__INSP_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TIB_CDCONCLUSIONINSPTMPOA" before insert
on OA.CD_CONCLUSION__INSP_TMP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_CONCLUSION_OA"
	cursor c1_cd_conclusion__insp_tmp_oa(Vcd_conclusion_oa__id_conc number) is
		select 1 
		from OA.CD_CONCLUSION_OA 
		where 
		ID_CONC = Vcd_conclusion_oa__id_conc and Vcd_conclusion_oa__id_conc is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.INSP_TMP_OA"
	cursor c2_cd_conclusion__insp_tmp_oa(Vcamp_oa__id_camp varchar,
	Vdsc_temp_oa__num_oa varchar) is
		select 1 
		from OA.INSP_TMP_OA 
		where 
		CAMP_OA__ID_CAMP = Vcamp_oa__id_camp and Vcamp_oa__id_camp is not null and 
		DSC_TEMP_OA__NUM_OA = Vdsc_temp_oa__num_oa and Vdsc_temp_oa__num_oa is not null;
begin

	
	--  Le parent "OA.CD_CONCLUSION_OA" doit exister à la création d'un enfant dans "OA.CD_CONCLUSION__INSP_TMP_OA"
	if :new.CD_CONCLUSION_OA__ID_CONC is not null then 
		open c1_cd_conclusion__insp_tmp_oa ( :new.CD_CONCLUSION_OA__ID_CONC);
		fetch c1_cd_conclusion__insp_tmp_oa into dummy;
		found := c1_cd_conclusion__insp_tmp_oa%FOUND;
		close c1_cd_conclusion__insp_tmp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_CONCLUSION_OA". Impossible de créer un enfant dans "OA.CD_CONCLUSION__INSP_TMP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.INSP_TMP_OA" doit exister à la création d'un enfant dans "OA.CD_CONCLUSION__INSP_TMP_OA"
	if :new.CAMP_OA__ID_CAMP is not null and 
	:new.DSC_TEMP_OA__NUM_OA is not null then 
		open c2_cd_conclusion__insp_tmp_oa ( :new.CAMP_OA__ID_CAMP,
		:new.DSC_TEMP_OA__NUM_OA);
		fetch c2_cd_conclusion__insp_tmp_oa into dummy;
		found := c2_cd_conclusion__insp_tmp_oa%FOUND;
		close c2_cd_conclusion__insp_tmp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.INSP_TMP_OA". Impossible de créer un enfant dans "OA.CD_CONCLUSION__INSP_TMP_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_CDCONCLUSIONINSPTMPOA" before update
on OA.CD_CONCLUSION__INSP_TMP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_CONCLUSION_OA"
	cursor c1_cd_conclusion__insp_tmp_oa (Vcd_conclusion_oa__id_conc number) is
		select 1 
		from OA.CD_CONCLUSION_OA 
		where 
		ID_CONC = Vcd_conclusion_oa__id_conc and Vcd_conclusion_oa__id_conc is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.INSP_TMP_OA"
	cursor c2_cd_conclusion__insp_tmp_oa (Vcamp_oa__id_camp varchar,
	Vdsc_temp_oa__num_oa varchar) is
		select 1 
		from OA.INSP_TMP_OA 
		where 
		CAMP_OA__ID_CAMP = Vcamp_oa__id_camp and Vcamp_oa__id_camp is not null and 
		DSC_TEMP_OA__NUM_OA = Vdsc_temp_oa__num_oa and Vdsc_temp_oa__num_oa is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.CD_CONCLUSION_OA" doit exister à la création d'un enfant dans "OA.CD_CONCLUSION__INSP_TMP_OA"
	if :new.CD_CONCLUSION_OA__ID_CONC is not null and seq = 0 then 
		open c1_cd_conclusion__insp_tmp_oa ( :new.CD_CONCLUSION_OA__ID_CONC);
		fetch c1_cd_conclusion__insp_tmp_oa into dummy;
		found := c1_cd_conclusion__insp_tmp_oa%FOUND;
		close c1_cd_conclusion__insp_tmp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_CONCLUSION_OA". Impossible de modifier un enfant dans "OA.CD_CONCLUSION__INSP_TMP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.INSP_TMP_OA" doit exister à la création d'un enfant dans "OA.CD_CONCLUSION__INSP_TMP_OA"
	if :new.CAMP_OA__ID_CAMP is not null and seq = 0 and 
	:new.DSC_TEMP_OA__NUM_OA is not null and seq = 0 then 
		open c2_cd_conclusion__insp_tmp_oa ( :new.CAMP_OA__ID_CAMP,
		:new.DSC_TEMP_OA__NUM_OA);
		fetch c2_cd_conclusion__insp_tmp_oa into dummy;
		found := c2_cd_conclusion__insp_tmp_oa%FOUND;
		close c2_cd_conclusion__insp_tmp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.INSP_TMP_OA". Impossible de modifier un enfant dans "OA.CD_CONCLUSION__INSP_TMP_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TIB_CONTACTOA" before insert
on OA.CONTACT_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.DOC_OA"
	cursor c1_contact_oa(Vdoc__id number) is
		select 1 
		from OA.DOC_OA 
		where 
		ID = Vdoc__id and Vdoc__id is not null;
begin

	
	--  Le parent "OA.DOC_OA" doit exister à la création d'un enfant dans "OA.CONTACT_OA"
	if :new.DOC__ID is not null then 
		open c1_contact_oa ( :new.DOC__ID);
		fetch c1_contact_oa into dummy;
		found := c1_contact_oa%FOUND;
		close c1_contact_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.DOC_OA". Impossible de créer un enfant dans "OA.CONTACT_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_CONTACTOA" before update
on OA.CONTACT_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.DOC_OA"
	cursor c1_contact_oa (Vdoc__id number) is
		select 1 
		from OA.DOC_OA 
		where 
		ID = Vdoc__id and Vdoc__id is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.DOC_OA" doit exister à la création d'un enfant dans "OA.CONTACT_OA"
	if :new.DOC__ID is not null and seq = 0 then 
		open c1_contact_oa ( :new.DOC__ID);
		fetch c1_contact_oa into dummy;
		found := c1_contact_oa%FOUND;
		close c1_contact_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.DOC_OA". Impossible de modifier un enfant dans "OA.CONTACT_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TIB_CLSDOCOA" before insert
on OA.CLS_DOC_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CLS_OA"
	cursor c1_cls_doc_oa(Vcls__id number) is
		select 1 
		from OA.CLS_OA 
		where 
		ID = Vcls__id and Vcls__id is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.DOC_OA"
	cursor c2_cls_doc_oa(Vdoc__id number) is
		select 1 
		from OA.DOC_OA 
		where 
		ID = Vdoc__id and Vdoc__id is not null;
begin

	
	--  Le parent "OA.CLS_OA" doit exister à la création d'un enfant dans "OA.CLS_DOC_OA"
	if :new.CLS__ID is not null then 
		open c1_cls_doc_oa ( :new.CLS__ID);
		fetch c1_cls_doc_oa into dummy;
		found := c1_cls_doc_oa%FOUND;
		close c1_cls_doc_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CLS_OA". Impossible de créer un enfant dans "OA.CLS_DOC_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.DOC_OA" doit exister à la création d'un enfant dans "OA.CLS_DOC_OA"
	if :new.DOC__ID is not null then 
		open c2_cls_doc_oa ( :new.DOC__ID);
		fetch c2_cls_doc_oa into dummy;
		found := c2_cls_doc_oa%FOUND;
		close c2_cls_doc_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.DOC_OA". Impossible de créer un enfant dans "OA.CLS_DOC_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_CLSDOCOA" before update
on OA.CLS_DOC_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CLS_OA"
	cursor c1_cls_doc_oa (Vcls__id number) is
		select 1 
		from OA.CLS_OA 
		where 
		ID = Vcls__id and Vcls__id is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.DOC_OA"
	cursor c2_cls_doc_oa (Vdoc__id number) is
		select 1 
		from OA.DOC_OA 
		where 
		ID = Vdoc__id and Vdoc__id is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.CLS_OA" doit exister à la création d'un enfant dans "OA.CLS_DOC_OA"
	if :new.CLS__ID is not null and seq = 0 then 
		open c1_cls_doc_oa ( :new.CLS__ID);
		fetch c1_cls_doc_oa into dummy;
		found := c1_cls_doc_oa%FOUND;
		close c1_cls_doc_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CLS_OA". Impossible de modifier un enfant dans "OA.CLS_DOC_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.DOC_OA" doit exister à la création d'un enfant dans "OA.CLS_DOC_OA"
	if :new.DOC__ID is not null and seq = 0 then 
		open c2_cls_doc_oa ( :new.DOC__ID);
		fetch c2_cls_doc_oa into dummy;
		found := c2_cls_doc_oa%FOUND;
		close c2_cls_doc_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.DOC_OA". Impossible de modifier un enfant dans "OA.CLS_DOC_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUA_CDCONTRAINTEOA" after update
of TYPE
on OA.CD_CONTRAINTE_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.CD_CONTRAINTE_OA" dans les enfants "OA.PREVISION_OA"
	if ((updating('TYPE') and :old.TYPE != :new.TYPE)) then 
		update OA.PREVISION_OA
		set CD_CONTRAINTE_OA__TYPE = :new.TYPE  
		where CD_CONTRAINTE_OA__TYPE = :old.TYPE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_CDCONTRAINTEOA" after delete
on OA.CD_CONTRAINTE_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.PREVISION_OA"
	delete OA.PREVISION_OA
	where CD_CONTRAINTE_OA__TYPE = :old.TYPE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TIB_ELTINSPOA" before insert
on OA.ELT_INSP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.INSP_OA"
	cursor c1_elt_insp_oa(Vdsc_oa__num_oa varchar,
	Vcamp_oa__id_camp varchar) is
		select 1 
		from OA.INSP_OA 
		where 
		DSC_OA__NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null and 
		CAMP_OA__ID_CAMP = Vcamp_oa__id_camp and Vcamp_oa__id_camp is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.ELT_OA"
	cursor c2_elt_insp_oa(Vgrp_oa__id_grp number,
	Vprt_oa__id_prt number,
	Vsprt_oa__id_sprt number,
	Velt_oa__id_elem number) is
		select 1 
		from OA.ELT_OA 
		where 
		GRP_OA__ID_GRP = Vgrp_oa__id_grp and Vgrp_oa__id_grp is not null and 
		PRT_OA__ID_PRT = Vprt_oa__id_prt and Vprt_oa__id_prt is not null and 
		SPRT_OA__ID_SPRT = Vsprt_oa__id_sprt and Vsprt_oa__id_sprt is not null and 
		ID_ELEM = Velt_oa__id_elem and Velt_oa__id_elem is not null;
begin

	
	--  Le parent "OA.INSP_OA" doit exister à la création d'un enfant dans "OA.ELT_INSP_OA"
	if :new.DSC_OA__NUM_OA is not null and 
	:new.CAMP_OA__ID_CAMP is not null then 
		open c1_elt_insp_oa ( :new.DSC_OA__NUM_OA,
		:new.CAMP_OA__ID_CAMP);
		fetch c1_elt_insp_oa into dummy;
		found := c1_elt_insp_oa%FOUND;
		close c1_elt_insp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.INSP_OA". Impossible de créer un enfant dans "OA.ELT_INSP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.ELT_OA" doit exister à la création d'un enfant dans "OA.ELT_INSP_OA"
	if :new.GRP_OA__ID_GRP is not null and 
	:new.PRT_OA__ID_PRT is not null and 
	:new.SPRT_OA__ID_SPRT is not null and 
	:new.ELT_OA__ID_ELEM is not null then 
		open c2_elt_insp_oa ( :new.GRP_OA__ID_GRP,
		:new.PRT_OA__ID_PRT,
		:new.SPRT_OA__ID_SPRT,
		:new.ELT_OA__ID_ELEM);
		fetch c2_elt_insp_oa into dummy;
		found := c2_elt_insp_oa%FOUND;
		close c2_elt_insp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.ELT_OA". Impossible de créer un enfant dans "OA.ELT_INSP_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_ELTINSPOA" before update
on OA.ELT_INSP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.INSP_OA"
	cursor c1_elt_insp_oa (Vdsc_oa__num_oa varchar,
	Vcamp_oa__id_camp varchar) is
		select 1 
		from OA.INSP_OA 
		where 
		DSC_OA__NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null and 
		CAMP_OA__ID_CAMP = Vcamp_oa__id_camp and Vcamp_oa__id_camp is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.ELT_OA"
	cursor c2_elt_insp_oa (Vgrp_oa__id_grp number,
	Vprt_oa__id_prt number,
	Vsprt_oa__id_sprt number,
	Velt_oa__id_elem number) is
		select 1 
		from OA.ELT_OA 
		where 
		GRP_OA__ID_GRP = Vgrp_oa__id_grp and Vgrp_oa__id_grp is not null and 
		PRT_OA__ID_PRT = Vprt_oa__id_prt and Vprt_oa__id_prt is not null and 
		SPRT_OA__ID_SPRT = Vsprt_oa__id_sprt and Vsprt_oa__id_sprt is not null and 
		ID_ELEM = Velt_oa__id_elem and Velt_oa__id_elem is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.INSP_OA" doit exister à la création d'un enfant dans "OA.ELT_INSP_OA"
	if :new.DSC_OA__NUM_OA is not null and seq = 0 and 
	:new.CAMP_OA__ID_CAMP is not null and seq = 0 then 
		open c1_elt_insp_oa ( :new.DSC_OA__NUM_OA,
		:new.CAMP_OA__ID_CAMP);
		fetch c1_elt_insp_oa into dummy;
		found := c1_elt_insp_oa%FOUND;
		close c1_elt_insp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.INSP_OA". Impossible de modifier un enfant dans "OA.ELT_INSP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.ELT_OA" doit exister à la création d'un enfant dans "OA.ELT_INSP_OA"
	if :new.GRP_OA__ID_GRP is not null and seq = 0 and 
	:new.PRT_OA__ID_PRT is not null and seq = 0 and 
	:new.SPRT_OA__ID_SPRT is not null and seq = 0 and 
	:new.ELT_OA__ID_ELEM is not null and seq = 0 then 
		open c2_elt_insp_oa ( :new.GRP_OA__ID_GRP,
		:new.PRT_OA__ID_PRT,
		:new.SPRT_OA__ID_SPRT,
		:new.ELT_OA__ID_ELEM);
		fetch c2_elt_insp_oa into dummy;
		found := c2_elt_insp_oa%FOUND;
		close c2_elt_insp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.ELT_OA". Impossible de modifier un enfant dans "OA.ELT_INSP_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUA_ELTINSPOA" after update
of GRP_OA__ID_GRP,PRT_OA__ID_PRT,SPRT_OA__ID_SPRT,DSC_OA__NUM_OA,CAMP_OA__ID_CAMP,ELT_OA__ID_ELEM
on OA.ELT_INSP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.ELT_INSP_OA" dans les enfants "OA.PHOTO_ELT_INSP_OA"
	if ((updating('GRP_OA__ID_GRP') and :old.GRP_OA__ID_GRP != :new.GRP_OA__ID_GRP) or 
	(updating('PRT_OA__ID_PRT') and :old.PRT_OA__ID_PRT != :new.PRT_OA__ID_PRT) or 
	(updating('SPRT_OA__ID_SPRT') and :old.SPRT_OA__ID_SPRT != :new.SPRT_OA__ID_SPRT) or 
	(updating('DSC_OA__NUM_OA') and :old.DSC_OA__NUM_OA != :new.DSC_OA__NUM_OA) or 
	(updating('CAMP_OA__ID_CAMP') and :old.CAMP_OA__ID_CAMP != :new.CAMP_OA__ID_CAMP) or 
	(updating('ELT_OA__ID_ELEM') and :old.ELT_OA__ID_ELEM != :new.ELT_OA__ID_ELEM)) then 
		update OA.PHOTO_ELT_INSP_OA
		set GRP_OA__ID_GRP = :new.GRP_OA__ID_GRP,
		PRT_OA__ID_PRT = :new.PRT_OA__ID_PRT,
		SPRT_OA__ID_SPRT = :new.SPRT_OA__ID_SPRT,
		DSC_OA__NUM_OA = :new.DSC_OA__NUM_OA,
		CAMP_OA__ID_CAMP = :new.CAMP_OA__ID_CAMP,
		ELT_OA__ID_ELEM = :new.ELT_OA__ID_ELEM  
		where GRP_OA__ID_GRP = :old.GRP_OA__ID_GRP and 
		PRT_OA__ID_PRT = :old.PRT_OA__ID_PRT and 
		SPRT_OA__ID_SPRT = :old.SPRT_OA__ID_SPRT and 
		DSC_OA__NUM_OA = :old.DSC_OA__NUM_OA and 
		CAMP_OA__ID_CAMP = :old.CAMP_OA__ID_CAMP and 
		ELT_OA__ID_ELEM = :old.ELT_OA__ID_ELEM;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_ELTINSPOA" after delete
on OA.ELT_INSP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.PHOTO_ELT_INSP_OA"
	delete OA.PHOTO_ELT_INSP_OA
	where GRP_OA__ID_GRP = :old.GRP_OA__ID_GRP and 
	PRT_OA__ID_PRT = :old.PRT_OA__ID_PRT and 
	SPRT_OA__ID_SPRT = :old.SPRT_OA__ID_SPRT and 
	DSC_OA__NUM_OA = :old.DSC_OA__NUM_OA and 
	CAMP_OA__ID_CAMP = :old.CAMP_OA__ID_CAMP and 
	ELT_OA__ID_ELEM = :old.ELT_OA__ID_ELEM;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TIB_ELTINSPTMPOA" before insert
on OA.ELT_INSP_TMP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.INSP_TMP_OA"
	cursor c1_elt_insp_tmp_oa(Vcamp_oa__id_camp varchar,
	Vdsc_temp_oa__num_oa varchar) is
		select 1 
		from OA.INSP_TMP_OA 
		where 
		CAMP_OA__ID_CAMP = Vcamp_oa__id_camp and Vcamp_oa__id_camp is not null and 
		DSC_TEMP_OA__NUM_OA = Vdsc_temp_oa__num_oa and Vdsc_temp_oa__num_oa is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.ELT_OA"
	cursor c2_elt_insp_tmp_oa(Vgrp_oa__id_grp number,
	Vprt_oa__id_prt number,
	Vsprt_oa__id_sprt number,
	Velt_oa__id_elem number) is
		select 1 
		from OA.ELT_OA 
		where 
		GRP_OA__ID_GRP = Vgrp_oa__id_grp and Vgrp_oa__id_grp is not null and 
		PRT_OA__ID_PRT = Vprt_oa__id_prt and Vprt_oa__id_prt is not null and 
		SPRT_OA__ID_SPRT = Vsprt_oa__id_sprt and Vsprt_oa__id_sprt is not null and 
		ID_ELEM = Velt_oa__id_elem and Velt_oa__id_elem is not null;
begin

	
	--  Le parent "OA.INSP_TMP_OA" doit exister à la création d'un enfant dans "OA.ELT_INSP_TMP_OA"
	if :new.CAMP_OA__ID_CAMP is not null and 
	:new.DSC_TEMP_OA__NUM_OA is not null then 
		open c1_elt_insp_tmp_oa ( :new.CAMP_OA__ID_CAMP,
		:new.DSC_TEMP_OA__NUM_OA);
		fetch c1_elt_insp_tmp_oa into dummy;
		found := c1_elt_insp_tmp_oa%FOUND;
		close c1_elt_insp_tmp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.INSP_TMP_OA". Impossible de créer un enfant dans "OA.ELT_INSP_TMP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.ELT_OA" doit exister à la création d'un enfant dans "OA.ELT_INSP_TMP_OA"
	if :new.GRP_OA__ID_GRP is not null and 
	:new.PRT_OA__ID_PRT is not null and 
	:new.SPRT_OA__ID_SPRT is not null and 
	:new.ELT_OA__ID_ELEM is not null then 
		open c2_elt_insp_tmp_oa ( :new.GRP_OA__ID_GRP,
		:new.PRT_OA__ID_PRT,
		:new.SPRT_OA__ID_SPRT,
		:new.ELT_OA__ID_ELEM);
		fetch c2_elt_insp_tmp_oa into dummy;
		found := c2_elt_insp_tmp_oa%FOUND;
		close c2_elt_insp_tmp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.ELT_OA". Impossible de créer un enfant dans "OA.ELT_INSP_TMP_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_ELTINSPTMPOA" before update
on OA.ELT_INSP_TMP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.INSP_TMP_OA"
	cursor c1_elt_insp_tmp_oa (Vcamp_oa__id_camp varchar,
	Vdsc_temp_oa__num_oa varchar) is
		select 1 
		from OA.INSP_TMP_OA 
		where 
		CAMP_OA__ID_CAMP = Vcamp_oa__id_camp and Vcamp_oa__id_camp is not null and 
		DSC_TEMP_OA__NUM_OA = Vdsc_temp_oa__num_oa and Vdsc_temp_oa__num_oa is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.ELT_OA"
	cursor c2_elt_insp_tmp_oa (Vgrp_oa__id_grp number,
	Vprt_oa__id_prt number,
	Vsprt_oa__id_sprt number,
	Velt_oa__id_elem number) is
		select 1 
		from OA.ELT_OA 
		where 
		GRP_OA__ID_GRP = Vgrp_oa__id_grp and Vgrp_oa__id_grp is not null and 
		PRT_OA__ID_PRT = Vprt_oa__id_prt and Vprt_oa__id_prt is not null and 
		SPRT_OA__ID_SPRT = Vsprt_oa__id_sprt and Vsprt_oa__id_sprt is not null and 
		ID_ELEM = Velt_oa__id_elem and Velt_oa__id_elem is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.INSP_TMP_OA" doit exister à la création d'un enfant dans "OA.ELT_INSP_TMP_OA"
	if :new.CAMP_OA__ID_CAMP is not null and seq = 0 and 
	:new.DSC_TEMP_OA__NUM_OA is not null and seq = 0 then 
		open c1_elt_insp_tmp_oa ( :new.CAMP_OA__ID_CAMP,
		:new.DSC_TEMP_OA__NUM_OA);
		fetch c1_elt_insp_tmp_oa into dummy;
		found := c1_elt_insp_tmp_oa%FOUND;
		close c1_elt_insp_tmp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.INSP_TMP_OA". Impossible de modifier un enfant dans "OA.ELT_INSP_TMP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.ELT_OA" doit exister à la création d'un enfant dans "OA.ELT_INSP_TMP_OA"
	if :new.GRP_OA__ID_GRP is not null and seq = 0 and 
	:new.PRT_OA__ID_PRT is not null and seq = 0 and 
	:new.SPRT_OA__ID_SPRT is not null and seq = 0 and 
	:new.ELT_OA__ID_ELEM is not null and seq = 0 then 
		open c2_elt_insp_tmp_oa ( :new.GRP_OA__ID_GRP,
		:new.PRT_OA__ID_PRT,
		:new.SPRT_OA__ID_SPRT,
		:new.ELT_OA__ID_ELEM);
		fetch c2_elt_insp_tmp_oa into dummy;
		found := c2_elt_insp_tmp_oa%FOUND;
		close c2_elt_insp_tmp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.ELT_OA". Impossible de modifier un enfant dans "OA.ELT_INSP_TMP_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUA_ELTINSPTMPOA" after update
of GRP_OA__ID_GRP,PRT_OA__ID_PRT,SPRT_OA__ID_SPRT,CAMP_OA__ID_CAMP,DSC_TEMP_OA__NUM_OA,ELT_OA__ID_ELEM
on OA.ELT_INSP_TMP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.ELT_INSP_TMP_OA" dans les enfants "OA.PHOTO_ELT_INSP_TMP_OA"
	if ((updating('GRP_OA__ID_GRP') and :old.GRP_OA__ID_GRP != :new.GRP_OA__ID_GRP) or 
	(updating('PRT_OA__ID_PRT') and :old.PRT_OA__ID_PRT != :new.PRT_OA__ID_PRT) or 
	(updating('SPRT_OA__ID_SPRT') and :old.SPRT_OA__ID_SPRT != :new.SPRT_OA__ID_SPRT) or 
	(updating('CAMP_OA__ID_CAMP') and :old.CAMP_OA__ID_CAMP != :new.CAMP_OA__ID_CAMP) or 
	(updating('DSC_TEMP_OA__NUM_OA') and :old.DSC_TEMP_OA__NUM_OA != :new.DSC_TEMP_OA__NUM_OA) or 
	(updating('ELT_OA__ID_ELEM') and :old.ELT_OA__ID_ELEM != :new.ELT_OA__ID_ELEM)) then 
		update OA.PHOTO_ELT_INSP_TMP_OA
		set GRP_OA__ID_GRP = :new.GRP_OA__ID_GRP,
		PRT_OA__ID_PRT = :new.PRT_OA__ID_PRT,
		SPRT_OA__ID_SPRT = :new.SPRT_OA__ID_SPRT,
		CAMP_OA__ID_CAMP = :new.CAMP_OA__ID_CAMP,
		DSC_TEMP_OA__NUM_OA = :new.DSC_TEMP_OA__NUM_OA,
		ELT_OA__ID_ELEM = :new.ELT_OA__ID_ELEM  
		where GRP_OA__ID_GRP = :old.GRP_OA__ID_GRP and 
		PRT_OA__ID_PRT = :old.PRT_OA__ID_PRT and 
		SPRT_OA__ID_SPRT = :old.SPRT_OA__ID_SPRT and 
		CAMP_OA__ID_CAMP = :old.CAMP_OA__ID_CAMP and 
		DSC_TEMP_OA__NUM_OA = :old.DSC_TEMP_OA__NUM_OA and 
		ELT_OA__ID_ELEM = :old.ELT_OA__ID_ELEM;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_ELTINSPTMPOA" after delete
on OA.ELT_INSP_TMP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.PHOTO_ELT_INSP_TMP_OA"
	delete OA.PHOTO_ELT_INSP_TMP_OA
	where GRP_OA__ID_GRP = :old.GRP_OA__ID_GRP and 
	PRT_OA__ID_PRT = :old.PRT_OA__ID_PRT and 
	SPRT_OA__ID_SPRT = :old.SPRT_OA__ID_SPRT and 
	CAMP_OA__ID_CAMP = :old.CAMP_OA__ID_CAMP and 
	DSC_TEMP_OA__NUM_OA = :old.DSC_TEMP_OA__NUM_OA and 
	ELT_OA__ID_ELEM = :old.ELT_OA__ID_ELEM;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TIB_SPRTVSTOA" before insert
on OA.SPRT_VST_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.VST_OA"
	cursor c1_sprt_vst_oa(Vdsc_oa__num_oa varchar,
	Vcamp_oa__id_camp varchar) is
		select 1 
		from OA.VST_OA 
		where 
		DSC_OA__NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null and 
		CAMP_OA__ID_CAMP = Vcamp_oa__id_camp and Vcamp_oa__id_camp is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_LIGNE_OA"
	cursor c2_sprt_vst_oa(Vcd_chapitre_oa__id_chap number,
	Vcd_ligne_oa__id_ligne number) is
		select 1 
		from OA.CD_LIGNE_OA 
		where 
		CD_CHAPITRE_OA__ID_CHAP = Vcd_chapitre_oa__id_chap and Vcd_chapitre_oa__id_chap is not null and 
		ID_LIGNE = Vcd_ligne_oa__id_ligne and Vcd_ligne_oa__id_ligne is not null;
begin

	
	--  Le parent "OA.VST_OA" doit exister à la création d'un enfant dans "OA.SPRT_VST_OA"
	if :new.DSC_OA__NUM_OA is not null and 
	:new.CAMP_OA__ID_CAMP is not null then 
		open c1_sprt_vst_oa ( :new.DSC_OA__NUM_OA,
		:new.CAMP_OA__ID_CAMP);
		fetch c1_sprt_vst_oa into dummy;
		found := c1_sprt_vst_oa%FOUND;
		close c1_sprt_vst_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.VST_OA". Impossible de créer un enfant dans "OA.SPRT_VST_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_LIGNE_OA" doit exister à la création d'un enfant dans "OA.SPRT_VST_OA"
	if :new.CD_CHAPITRE_OA__ID_CHAP is not null and 
	:new.CD_LIGNE_OA__ID_LIGNE is not null then 
		open c2_sprt_vst_oa ( :new.CD_CHAPITRE_OA__ID_CHAP,
		:new.CD_LIGNE_OA__ID_LIGNE);
		fetch c2_sprt_vst_oa into dummy;
		found := c2_sprt_vst_oa%FOUND;
		close c2_sprt_vst_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_LIGNE_OA". Impossible de créer un enfant dans "OA.SPRT_VST_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_SPRTVSTOA" before update
on OA.SPRT_VST_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.VST_OA"
	cursor c1_sprt_vst_oa (Vdsc_oa__num_oa varchar,
	Vcamp_oa__id_camp varchar) is
		select 1 
		from OA.VST_OA 
		where 
		DSC_OA__NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null and 
		CAMP_OA__ID_CAMP = Vcamp_oa__id_camp and Vcamp_oa__id_camp is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_LIGNE_OA"
	cursor c2_sprt_vst_oa (Vcd_chapitre_oa__id_chap number,
	Vcd_ligne_oa__id_ligne number) is
		select 1 
		from OA.CD_LIGNE_OA 
		where 
		CD_CHAPITRE_OA__ID_CHAP = Vcd_chapitre_oa__id_chap and Vcd_chapitre_oa__id_chap is not null and 
		ID_LIGNE = Vcd_ligne_oa__id_ligne and Vcd_ligne_oa__id_ligne is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.VST_OA" doit exister à la création d'un enfant dans "OA.SPRT_VST_OA"
	if :new.DSC_OA__NUM_OA is not null and seq = 0 and 
	:new.CAMP_OA__ID_CAMP is not null and seq = 0 then 
		open c1_sprt_vst_oa ( :new.DSC_OA__NUM_OA,
		:new.CAMP_OA__ID_CAMP);
		fetch c1_sprt_vst_oa into dummy;
		found := c1_sprt_vst_oa%FOUND;
		close c1_sprt_vst_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.VST_OA". Impossible de modifier un enfant dans "OA.SPRT_VST_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_LIGNE_OA" doit exister à la création d'un enfant dans "OA.SPRT_VST_OA"
	if :new.CD_CHAPITRE_OA__ID_CHAP is not null and seq = 0 and 
	:new.CD_LIGNE_OA__ID_LIGNE is not null and seq = 0 then 
		open c2_sprt_vst_oa ( :new.CD_CHAPITRE_OA__ID_CHAP,
		:new.CD_LIGNE_OA__ID_LIGNE);
		fetch c2_sprt_vst_oa into dummy;
		found := c2_sprt_vst_oa%FOUND;
		close c2_sprt_vst_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_LIGNE_OA". Impossible de modifier un enfant dans "OA.SPRT_VST_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUA_SPRTVSTOA" after update
of DSC_OA__NUM_OA,CAMP_OA__ID_CAMP,CD_CHAPITRE_OA__ID_CHAP,CD_LIGNE_OA__ID_LIGNE
on OA.SPRT_VST_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.SPRT_VST_OA" dans les enfants "OA.PHOTO_SPRT_VST_OA"
	if ((updating('DSC_OA__NUM_OA') and :old.DSC_OA__NUM_OA != :new.DSC_OA__NUM_OA) or 
	(updating('CAMP_OA__ID_CAMP') and :old.CAMP_OA__ID_CAMP != :new.CAMP_OA__ID_CAMP) or 
	(updating('CD_CHAPITRE_OA__ID_CHAP') and :old.CD_CHAPITRE_OA__ID_CHAP != :new.CD_CHAPITRE_OA__ID_CHAP) or 
	(updating('CD_LIGNE_OA__ID_LIGNE') and :old.CD_LIGNE_OA__ID_LIGNE != :new.CD_LIGNE_OA__ID_LIGNE)) then 
		update OA.PHOTO_SPRT_VST_OA
		set DSC_OA__NUM_OA = :new.DSC_OA__NUM_OA,
		CAMP_OA__ID_CAMP = :new.CAMP_OA__ID_CAMP,
		CD_CHAPITRE_OA__ID_CHAP = :new.CD_CHAPITRE_OA__ID_CHAP,
		CD_LIGNE_OA__ID_LIGNE = :new.CD_LIGNE_OA__ID_LIGNE  
		where DSC_OA__NUM_OA = :old.DSC_OA__NUM_OA and 
		CAMP_OA__ID_CAMP = :old.CAMP_OA__ID_CAMP and 
		CD_CHAPITRE_OA__ID_CHAP = :old.CD_CHAPITRE_OA__ID_CHAP and 
		CD_LIGNE_OA__ID_LIGNE = :old.CD_LIGNE_OA__ID_LIGNE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_SPRTVSTOA" after delete
on OA.SPRT_VST_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.PHOTO_SPRT_VST_OA"
	delete OA.PHOTO_SPRT_VST_OA
	where DSC_OA__NUM_OA = :old.DSC_OA__NUM_OA and 
	CAMP_OA__ID_CAMP = :old.CAMP_OA__ID_CAMP and 
	CD_CHAPITRE_OA__ID_CHAP = :old.CD_CHAPITRE_OA__ID_CHAP and 
	CD_LIGNE_OA__ID_LIGNE = :old.CD_LIGNE_OA__ID_LIGNE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TIB_DOCOA" before insert
on OA.DOC_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_DOC_OA"
	cursor c1_doc_oa(Vcd_doc__code varchar) is
		select 1 
		from OA.CD_DOC_OA 
		where 
		CODE = Vcd_doc__code and Vcd_doc__code is not null;
begin

	
	--  Le parent "OA.CD_DOC_OA" doit exister à la création d'un enfant dans "OA.DOC_OA"
	if :new.CD_DOC__CODE is not null then 
		open c1_doc_oa ( :new.CD_DOC__CODE);
		fetch c1_doc_oa into dummy;
		found := c1_doc_oa%FOUND;
		close c1_doc_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_DOC_OA". Impossible de créer un enfant dans "OA.DOC_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_DOCOA" before update
on OA.DOC_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_DOC_OA"
	cursor c1_doc_oa (Vcd_doc__code varchar) is
		select 1 
		from OA.CD_DOC_OA 
		where 
		CODE = Vcd_doc__code and Vcd_doc__code is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.CD_DOC_OA" doit exister à la création d'un enfant dans "OA.DOC_OA"
	if :new.CD_DOC__CODE is not null and seq = 0 then 
		open c1_doc_oa ( :new.CD_DOC__CODE);
		fetch c1_doc_oa into dummy;
		found := c1_doc_oa%FOUND;
		close c1_doc_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_DOC_OA". Impossible de modifier un enfant dans "OA.DOC_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUA_DOCOA" after update
of ID
on OA.DOC_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.DOC_OA" dans les enfants "OA.CONTACT_OA"
	if ((updating('ID') and :old.ID != :new.ID)) then 
		update OA.CONTACT_OA
		set DOC__ID = :new.ID  
		where DOC__ID = :old.ID;
	end if;
	--  Modification du code du parent "OA.DOC_OA" dans les enfants "OA.CLS_DOC_OA"
	if ((updating('ID') and :old.ID != :new.ID)) then 
		update OA.CLS_DOC_OA
		set DOC__ID = :new.ID  
		where DOC__ID = :old.ID;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_DOCOA" after delete
on OA.DOC_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.CONTACT_OA"
	delete OA.CONTACT_OA
	where DOC__ID = :old.ID;
	
	--  Suppression des enfants dans "OA.CLS_DOC_OA"
	delete OA.CLS_DOC_OA
	where DOC__ID = :old.ID;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TIB_DSCARCHIVE3OA" before insert
on OA.DSC__ARCHIVE_3_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.ARCHIVE_3_OA"
	cursor c1_dsc__archive_3_oa(Varchive_3_oa__date_calc date) is
		select 1 
		from OA.ARCHIVE_3_OA 
		where 
		DATE_CALC = Varchive_3_oa__date_calc and Varchive_3_oa__date_calc is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.DSC_OA"
	cursor c2_dsc__archive_3_oa(Vdsc_oa__num_oa varchar) is
		select 1 
		from OA.DSC_OA 
		where 
		NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null;
begin

	
	--  Le parent "OA.ARCHIVE_3_OA" doit exister à la création d'un enfant dans "OA.DSC__ARCHIVE_3_OA"
	if :new.ARCHIVE_3_OA__DATE_CALC is not null then 
		open c1_dsc__archive_3_oa ( :new.ARCHIVE_3_OA__DATE_CALC);
		fetch c1_dsc__archive_3_oa into dummy;
		found := c1_dsc__archive_3_oa%FOUND;
		close c1_dsc__archive_3_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.ARCHIVE_3_OA". Impossible de créer un enfant dans "OA.DSC__ARCHIVE_3_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.DSC_OA" doit exister à la création d'un enfant dans "OA.DSC__ARCHIVE_3_OA"
	if :new.DSC_OA__NUM_OA is not null then 
		open c2_dsc__archive_3_oa ( :new.DSC_OA__NUM_OA);
		fetch c2_dsc__archive_3_oa into dummy;
		found := c2_dsc__archive_3_oa%FOUND;
		close c2_dsc__archive_3_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.DSC_OA". Impossible de créer un enfant dans "OA.DSC__ARCHIVE_3_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_DSCARCHIVE3OA" before update
on OA.DSC__ARCHIVE_3_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.ARCHIVE_3_OA"
	cursor c1_dsc__archive_3_oa (Varchive_3_oa__date_calc date) is
		select 1 
		from OA.ARCHIVE_3_OA 
		where 
		DATE_CALC = Varchive_3_oa__date_calc and Varchive_3_oa__date_calc is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.DSC_OA"
	cursor c2_dsc__archive_3_oa (Vdsc_oa__num_oa varchar) is
		select 1 
		from OA.DSC_OA 
		where 
		NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.ARCHIVE_3_OA" doit exister à la création d'un enfant dans "OA.DSC__ARCHIVE_3_OA"
	if :new.ARCHIVE_3_OA__DATE_CALC is not null and seq = 0 then 
		open c1_dsc__archive_3_oa ( :new.ARCHIVE_3_OA__DATE_CALC);
		fetch c1_dsc__archive_3_oa into dummy;
		found := c1_dsc__archive_3_oa%FOUND;
		close c1_dsc__archive_3_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.ARCHIVE_3_OA". Impossible de modifier un enfant dans "OA.DSC__ARCHIVE_3_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.DSC_OA" doit exister à la création d'un enfant dans "OA.DSC__ARCHIVE_3_OA"
	if :new.DSC_OA__NUM_OA is not null and seq = 0 then 
		open c2_dsc__archive_3_oa ( :new.DSC_OA__NUM_OA);
		fetch c2_dsc__archive_3_oa into dummy;
		found := c2_dsc__archive_3_oa%FOUND;
		close c2_dsc__archive_3_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.DSC_OA". Impossible de modifier un enfant dans "OA.DSC__ARCHIVE_3_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TIB_ELTOA" before insert
on OA.ELT_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.SPRT_OA"
	cursor c1_elt_oa(Vgrp_oa__id_grp number,
	Vprt_oa__id_prt number,
	Vsprt_oa__id_sprt number) is
		select 1 
		from OA.SPRT_OA 
		where 
		GRP_OA__ID_GRP = Vgrp_oa__id_grp and Vgrp_oa__id_grp is not null and 
		PRT_OA__ID_PRT = Vprt_oa__id_prt and Vprt_oa__id_prt is not null and 
		ID_SPRT = Vsprt_oa__id_sprt and Vsprt_oa__id_sprt is not null;
begin

	
	--  Le parent "OA.SPRT_OA" doit exister à la création d'un enfant dans "OA.ELT_OA"
	if :new.GRP_OA__ID_GRP is not null and 
	:new.PRT_OA__ID_PRT is not null and 
	:new.SPRT_OA__ID_SPRT is not null then 
		open c1_elt_oa ( :new.GRP_OA__ID_GRP,
		:new.PRT_OA__ID_PRT,
		:new.SPRT_OA__ID_SPRT);
		fetch c1_elt_oa into dummy;
		found := c1_elt_oa%FOUND;
		close c1_elt_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.SPRT_OA". Impossible de créer un enfant dans "OA.ELT_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_ELTOA" before update
on OA.ELT_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.SPRT_OA"
	cursor c1_elt_oa (Vgrp_oa__id_grp number,
	Vprt_oa__id_prt number,
	Vsprt_oa__id_sprt number) is
		select 1 
		from OA.SPRT_OA 
		where 
		GRP_OA__ID_GRP = Vgrp_oa__id_grp and Vgrp_oa__id_grp is not null and 
		PRT_OA__ID_PRT = Vprt_oa__id_prt and Vprt_oa__id_prt is not null and 
		ID_SPRT = Vsprt_oa__id_sprt and Vsprt_oa__id_sprt is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.SPRT_OA" doit exister à la création d'un enfant dans "OA.ELT_OA"
	if :new.GRP_OA__ID_GRP is not null and seq = 0 and 
	:new.PRT_OA__ID_PRT is not null and seq = 0 and 
	:new.SPRT_OA__ID_SPRT is not null and seq = 0 then 
		open c1_elt_oa ( :new.GRP_OA__ID_GRP,
		:new.PRT_OA__ID_PRT,
		:new.SPRT_OA__ID_SPRT);
		fetch c1_elt_oa into dummy;
		found := c1_elt_oa%FOUND;
		close c1_elt_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.SPRT_OA". Impossible de modifier un enfant dans "OA.ELT_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUA_ELTOA" after update
of GRP_OA__ID_GRP,PRT_OA__ID_PRT,SPRT_OA__ID_SPRT,ID_ELEM
on OA.ELT_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.ELT_OA" dans les enfants "OA.ELT_INSP_OA"
	if ((updating('GRP_OA__ID_GRP') and :old.GRP_OA__ID_GRP != :new.GRP_OA__ID_GRP) or 
	(updating('PRT_OA__ID_PRT') and :old.PRT_OA__ID_PRT != :new.PRT_OA__ID_PRT) or 
	(updating('SPRT_OA__ID_SPRT') and :old.SPRT_OA__ID_SPRT != :new.SPRT_OA__ID_SPRT) or 
	(updating('ID_ELEM') and :old.ID_ELEM != :new.ID_ELEM)) then 
		update OA.ELT_INSP_OA
		set GRP_OA__ID_GRP = :new.GRP_OA__ID_GRP,
		PRT_OA__ID_PRT = :new.PRT_OA__ID_PRT,
		SPRT_OA__ID_SPRT = :new.SPRT_OA__ID_SPRT,
		ELT_OA__ID_ELEM = :new.ID_ELEM  
		where GRP_OA__ID_GRP = :old.GRP_OA__ID_GRP and 
		PRT_OA__ID_PRT = :old.PRT_OA__ID_PRT and 
		SPRT_OA__ID_SPRT = :old.SPRT_OA__ID_SPRT and 
		ELT_OA__ID_ELEM = :old.ID_ELEM;
	end if;
	--  Modification du code du parent "OA.ELT_OA" dans les enfants "OA.ELT_INSP_TMP_OA"
	if ((updating('GRP_OA__ID_GRP') and :old.GRP_OA__ID_GRP != :new.GRP_OA__ID_GRP) or 
	(updating('PRT_OA__ID_PRT') and :old.PRT_OA__ID_PRT != :new.PRT_OA__ID_PRT) or 
	(updating('SPRT_OA__ID_SPRT') and :old.SPRT_OA__ID_SPRT != :new.SPRT_OA__ID_SPRT) or 
	(updating('ID_ELEM') and :old.ID_ELEM != :new.ID_ELEM)) then 
		update OA.ELT_INSP_TMP_OA
		set GRP_OA__ID_GRP = :new.GRP_OA__ID_GRP,
		PRT_OA__ID_PRT = :new.PRT_OA__ID_PRT,
		SPRT_OA__ID_SPRT = :new.SPRT_OA__ID_SPRT,
		ELT_OA__ID_ELEM = :new.ID_ELEM  
		where GRP_OA__ID_GRP = :old.GRP_OA__ID_GRP and 
		PRT_OA__ID_PRT = :old.PRT_OA__ID_PRT and 
		SPRT_OA__ID_SPRT = :old.SPRT_OA__ID_SPRT and 
		ELT_OA__ID_ELEM = :old.ID_ELEM;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_ELTOA" after delete
on OA.ELT_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.ELT_INSP_OA"
	delete OA.ELT_INSP_OA
	where GRP_OA__ID_GRP = :old.GRP_OA__ID_GRP and 
	PRT_OA__ID_PRT = :old.PRT_OA__ID_PRT and 
	SPRT_OA__ID_SPRT = :old.SPRT_OA__ID_SPRT and 
	ELT_OA__ID_ELEM = :old.ID_ELEM;
	
	--  Suppression des enfants dans "OA.ELT_INSP_TMP_OA"
	delete OA.ELT_INSP_TMP_OA
	where GRP_OA__ID_GRP = :old.GRP_OA__ID_GRP and 
	PRT_OA__ID_PRT = :old.PRT_OA__ID_PRT and 
	SPRT_OA__ID_SPRT = :old.SPRT_OA__ID_SPRT and 
	ELT_OA__ID_ELEM = :old.ID_ELEM;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TIB_CDENTETEOA" before insert
on OA.CD_ENTETE_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_COMPOSANT_OA"
	cursor c1_cd_entete_oa(Vcd_composant_oa__type_comp varchar) is
		select 1 
		from OA.CD_COMPOSANT_OA 
		where 
		TYPE_COMP = Vcd_composant_oa__type_comp and Vcd_composant_oa__type_comp is not null;
begin

	
	--  Le parent "OA.CD_COMPOSANT_OA" doit exister à la création d'un enfant dans "OA.CD_ENTETE_OA"
	if :new.CD_COMPOSANT_OA__TYPE_COMP is not null then 
		open c1_cd_entete_oa ( :new.CD_COMPOSANT_OA__TYPE_COMP);
		fetch c1_cd_entete_oa into dummy;
		found := c1_cd_entete_oa%FOUND;
		close c1_cd_entete_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_COMPOSANT_OA". Impossible de créer un enfant dans "OA.CD_ENTETE_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_CDENTETEOA" before update
on OA.CD_ENTETE_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_COMPOSANT_OA"
	cursor c1_cd_entete_oa (Vcd_composant_oa__type_comp varchar) is
		select 1 
		from OA.CD_COMPOSANT_OA 
		where 
		TYPE_COMP = Vcd_composant_oa__type_comp and Vcd_composant_oa__type_comp is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.CD_COMPOSANT_OA" doit exister à la création d'un enfant dans "OA.CD_ENTETE_OA"
	if :new.CD_COMPOSANT_OA__TYPE_COMP is not null and seq = 0 then 
		open c1_cd_entete_oa ( :new.CD_COMPOSANT_OA__TYPE_COMP);
		fetch c1_cd_entete_oa into dummy;
		found := c1_cd_entete_oa%FOUND;
		close c1_cd_entete_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_COMPOSANT_OA". Impossible de modifier un enfant dans "OA.CD_ENTETE_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUA_CDENTETEOA" after update
of ID_ENTETE
on OA.CD_ENTETE_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.CD_ENTETE_OA" dans les enfants "OA.ENTETE_OA"
	if ((updating('ID_ENTETE') and :old.ID_ENTETE != :new.ID_ENTETE)) then 
		update OA.ENTETE_OA
		set CD_ENTETE_OA__ID_ENTETE = :new.ID_ENTETE  
		where CD_ENTETE_OA__ID_ENTETE = :old.ID_ENTETE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_CDENTETEOA" after delete
on OA.CD_ENTETE_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.ENTETE_OA"
	delete OA.ENTETE_OA
	where CD_ENTETE_OA__ID_ENTETE = :old.ID_ENTETE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TUA_CDENTPOA" after update
of ENTREPRISE
on OA.CD_ENTP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.CD_ENTP_OA" dans les enfants "OA.DSC_OA"
	if ((updating('ENTREPRISE') and :old.ENTREPRISE != :new.ENTREPRISE)) then 
		update OA.DSC_OA
		set CD_ENTP_OA__ENTREPRISE = :new.ENTREPRISE  
		where CD_ENTP_OA__ENTREPRISE = :old.ENTREPRISE;
	end if;
	--  Modification du code du parent "OA.CD_ENTP_OA" dans les enfants "OA.TRAVAUX_OA"
	if ((updating('ENTREPRISE') and :old.ENTREPRISE != :new.ENTREPRISE)) then 
		update OA.TRAVAUX_OA
		set CD_ENTP_OA__ENTREPRISE = :new.ENTREPRISE  
		where CD_ENTP_OA__ENTREPRISE = :old.ENTREPRISE;
	end if;
	--  Modification du code du parent "OA.CD_ENTP_OA" dans les enfants "OA.TABLIER_OA"
	if ((updating('ENTREPRISE') and :old.ENTREPRISE != :new.ENTREPRISE)) then 
		update OA.TABLIER_OA
		set CD_ENTP_OA__ENTREPRISE = :new.ENTREPRISE  
		where CD_ENTP_OA__ENTREPRISE = :old.ENTREPRISE;
	end if;
	--  Modification du code du parent "OA.CD_ENTP_OA" dans les enfants "OA.DSC_TEMP_OA"
	if ((updating('ENTREPRISE') and :old.ENTREPRISE != :new.ENTREPRISE)) then 
		update OA.DSC_TEMP_OA
		set CD_ENTP_OA__ENTREPRISE = :new.ENTREPRISE  
		where CD_ENTP_OA__ENTREPRISE = :old.ENTREPRISE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_CDENTPOA" after delete
on OA.CD_ENTP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.DSC_OA"
	delete OA.DSC_OA
	where CD_ENTP_OA__ENTREPRISE = :old.ENTREPRISE;
	
	--  Suppression des enfants dans "OA.TRAVAUX_OA"
	delete OA.TRAVAUX_OA
	where CD_ENTP_OA__ENTREPRISE = :old.ENTREPRISE;
	
	--  Suppression des enfants dans "OA.TABLIER_OA"
	delete OA.TABLIER_OA
	where CD_ENTP_OA__ENTREPRISE = :old.ENTREPRISE;
	
	--  Suppression des enfants dans "OA.DSC_TEMP_OA"
	delete OA.DSC_TEMP_OA
	where CD_ENTP_OA__ENTREPRISE = :old.ENTREPRISE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TIB_EQUIPEMENTOA" before insert
on OA.EQUIPEMENT_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_DPR_OA"
	cursor c1_equipement_oa(Vcd_dpr_oa__dpr varchar) is
		select 1 
		from OA.CD_DPR_OA 
		where 
		DPR = Vcd_dpr_oa__dpr and Vcd_dpr_oa__dpr is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.TABLIER_OA"
	cursor c2_equipement_oa(Vdsc_oa__num_oa varchar,
	Vtablier_oa__num_tab number) is
		select 1 
		from OA.TABLIER_OA 
		where 
		DSC_OA__NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null and 
		NUM_TAB = Vtablier_oa__num_tab and Vtablier_oa__num_tab is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_GC_OA"
	cursor c3_equipement_oa(Vcd_gc_oa__garde_corps varchar) is
		select 1 
		from OA.CD_GC_OA 
		where 
		GARDE_CORPS = Vcd_gc_oa__garde_corps and Vcd_gc_oa__garde_corps is not null;
begin

	
	--  Le parent "OA.CD_DPR_OA" doit exister à la création d'un enfant dans "OA.EQUIPEMENT_OA"
	if :new.CD_DPR_OA__DPR is not null then 
		open c1_equipement_oa ( :new.CD_DPR_OA__DPR);
		fetch c1_equipement_oa into dummy;
		found := c1_equipement_oa%FOUND;
		close c1_equipement_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_DPR_OA". Impossible de créer un enfant dans "OA.EQUIPEMENT_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.TABLIER_OA" doit exister à la création d'un enfant dans "OA.EQUIPEMENT_OA"
	if :new.DSC_OA__NUM_OA is not null and 
	:new.TABLIER_OA__NUM_TAB is not null then 
		open c2_equipement_oa ( :new.DSC_OA__NUM_OA,
		:new.TABLIER_OA__NUM_TAB);
		fetch c2_equipement_oa into dummy;
		found := c2_equipement_oa%FOUND;
		close c2_equipement_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.TABLIER_OA". Impossible de créer un enfant dans "OA.EQUIPEMENT_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_GC_OA" doit exister à la création d'un enfant dans "OA.EQUIPEMENT_OA"
	if :new.CD_GC_OA__GARDE_CORPS is not null then 
		open c3_equipement_oa ( :new.CD_GC_OA__GARDE_CORPS);
		fetch c3_equipement_oa into dummy;
		found := c3_equipement_oa%FOUND;
		close c3_equipement_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_GC_OA". Impossible de créer un enfant dans "OA.EQUIPEMENT_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_EQUIPEMENTOA" before update
on OA.EQUIPEMENT_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_DPR_OA"
	cursor c1_equipement_oa (Vcd_dpr_oa__dpr varchar) is
		select 1 
		from OA.CD_DPR_OA 
		where 
		DPR = Vcd_dpr_oa__dpr and Vcd_dpr_oa__dpr is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.TABLIER_OA"
	cursor c2_equipement_oa (Vdsc_oa__num_oa varchar,
	Vtablier_oa__num_tab number) is
		select 1 
		from OA.TABLIER_OA 
		where 
		DSC_OA__NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null and 
		NUM_TAB = Vtablier_oa__num_tab and Vtablier_oa__num_tab is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_GC_OA"
	cursor c3_equipement_oa (Vcd_gc_oa__garde_corps varchar) is
		select 1 
		from OA.CD_GC_OA 
		where 
		GARDE_CORPS = Vcd_gc_oa__garde_corps and Vcd_gc_oa__garde_corps is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.CD_DPR_OA" doit exister à la création d'un enfant dans "OA.EQUIPEMENT_OA"
	if :new.CD_DPR_OA__DPR is not null and seq = 0 then 
		open c1_equipement_oa ( :new.CD_DPR_OA__DPR);
		fetch c1_equipement_oa into dummy;
		found := c1_equipement_oa%FOUND;
		close c1_equipement_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_DPR_OA". Impossible de modifier un enfant dans "OA.EQUIPEMENT_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.TABLIER_OA" doit exister à la création d'un enfant dans "OA.EQUIPEMENT_OA"
	if :new.DSC_OA__NUM_OA is not null and seq = 0 and 
	:new.TABLIER_OA__NUM_TAB is not null and seq = 0 then 
		open c2_equipement_oa ( :new.DSC_OA__NUM_OA,
		:new.TABLIER_OA__NUM_TAB);
		fetch c2_equipement_oa into dummy;
		found := c2_equipement_oa%FOUND;
		close c2_equipement_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.TABLIER_OA". Impossible de modifier un enfant dans "OA.EQUIPEMENT_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_GC_OA" doit exister à la création d'un enfant dans "OA.EQUIPEMENT_OA"
	if :new.CD_GC_OA__GARDE_CORPS is not null and seq = 0 then 
		open c3_equipement_oa ( :new.CD_GC_OA__GARDE_CORPS);
		fetch c3_equipement_oa into dummy;
		found := c3_equipement_oa%FOUND;
		close c3_equipement_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_GC_OA". Impossible de modifier un enfant dans "OA.EQUIPEMENT_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUA_CDETUDEOA" after update
of ETUDE
on OA.CD_ETUDE_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.CD_ETUDE_OA" dans les enfants "OA.INSP_OA"
	if ((updating('ETUDE') and :old.ETUDE != :new.ETUDE)) then 
		update OA.INSP_OA
		set CD_ETUDE_OA__ETUDE = :new.ETUDE  
		where CD_ETUDE_OA__ETUDE = :old.ETUDE;
	end if;
	--  Modification du code du parent "OA.CD_ETUDE_OA" dans les enfants "OA.INSP_TMP_OA"
	if ((updating('ETUDE') and :old.ETUDE != :new.ETUDE)) then 
		update OA.INSP_TMP_OA
		set CD_ETUDE_OA__ETUDE = :new.ETUDE  
		where CD_ETUDE_OA__ETUDE = :old.ETUDE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_CDETUDEOA" after delete
on OA.CD_ETUDE_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.INSP_OA"
	delete OA.INSP_OA
	where CD_ETUDE_OA__ETUDE = :old.ETUDE;
	
	--  Suppression des enfants dans "OA.INSP_TMP_OA"
	delete OA.INSP_TMP_OA
	where CD_ETUDE_OA__ETUDE = :old.ETUDE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TIB_EVTOA" before insert
on OA.EVT_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_EVT_OA"
	cursor c1_evt_oa(Vcd_evt_oa__type varchar) is
		select 1 
		from OA.CD_EVT_OA 
		where 
		TYPE = Vcd_evt_oa__type and Vcd_evt_oa__type is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.DSC_OA"
	cursor c2_evt_oa(Vdsc_oa__num_oa varchar) is
		select 1 
		from OA.DSC_OA 
		where 
		NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null;
begin

	
	--  Le parent "OA.CD_EVT_OA" doit exister à la création d'un enfant dans "OA.EVT_OA"
	if :new.CD_EVT_OA__TYPE is not null then 
		open c1_evt_oa ( :new.CD_EVT_OA__TYPE);
		fetch c1_evt_oa into dummy;
		found := c1_evt_oa%FOUND;
		close c1_evt_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_EVT_OA". Impossible de créer un enfant dans "OA.EVT_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.DSC_OA" doit exister à la création d'un enfant dans "OA.EVT_OA"
	if :new.DSC_OA__NUM_OA is not null then 
		open c2_evt_oa ( :new.DSC_OA__NUM_OA);
		fetch c2_evt_oa into dummy;
		found := c2_evt_oa%FOUND;
		close c2_evt_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.DSC_OA". Impossible de créer un enfant dans "OA.EVT_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_EVTOA" before update
on OA.EVT_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_EVT_OA"
	cursor c1_evt_oa (Vcd_evt_oa__type varchar) is
		select 1 
		from OA.CD_EVT_OA 
		where 
		TYPE = Vcd_evt_oa__type and Vcd_evt_oa__type is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.DSC_OA"
	cursor c2_evt_oa (Vdsc_oa__num_oa varchar) is
		select 1 
		from OA.DSC_OA 
		where 
		NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.CD_EVT_OA" doit exister à la création d'un enfant dans "OA.EVT_OA"
	if :new.CD_EVT_OA__TYPE is not null and seq = 0 then 
		open c1_evt_oa ( :new.CD_EVT_OA__TYPE);
		fetch c1_evt_oa into dummy;
		found := c1_evt_oa%FOUND;
		close c1_evt_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_EVT_OA". Impossible de modifier un enfant dans "OA.EVT_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.DSC_OA" doit exister à la création d'un enfant dans "OA.EVT_OA"
	if :new.DSC_OA__NUM_OA is not null and seq = 0 then 
		open c2_evt_oa ( :new.DSC_OA__NUM_OA);
		fetch c2_evt_oa into dummy;
		found := c2_evt_oa%FOUND;
		close c2_evt_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.DSC_OA". Impossible de modifier un enfant dans "OA.EVT_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUA_CDFAMOA" after update
of FAMILLE
on OA.CD_FAM_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.CD_FAM_OA" dans les enfants "OA.DSC_OA"
	if ((updating('FAMILLE') and :old.FAMILLE != :new.FAMILLE)) then 
		update OA.DSC_OA
		set CD_FAM_OA__FAMILLE = :new.FAMILLE  
		where CD_FAM_OA__FAMILLE = :old.FAMILLE;
	end if;
	--  Modification du code du parent "OA.CD_FAM_OA" dans les enfants "OA.DSC_TEMP_OA"
	if ((updating('FAMILLE') and :old.FAMILLE != :new.FAMILLE)) then 
		update OA.DSC_TEMP_OA
		set CD_FAM_OA__FAMILLE = :new.FAMILLE  
		where CD_FAM_OA__FAMILLE = :old.FAMILLE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_CDFAMOA" after delete
on OA.CD_FAM_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.DSC_OA"
	delete OA.DSC_OA
	where CD_FAM_OA__FAMILLE = :old.FAMILLE;
	
	--  Suppression des enfants dans "OA.DSC_TEMP_OA"
	delete OA.DSC_TEMP_OA
	where CD_FAM_OA__FAMILLE = :old.FAMILLE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TUA_CDFAMAPPUIOA" after update
of FAM_APP
on OA.CD_FAM_APPUI_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.CD_FAM_APPUI_OA" dans les enfants "OA.APPUIS_OA"
	if ((updating('FAM_APP') and :old.FAM_APP != :new.FAM_APP)) then 
		update OA.APPUIS_OA
		set CD_FAM_APPUI_OA__FAM_APP = :new.FAM_APP  
		where CD_FAM_APPUI_OA__FAM_APP = :old.FAM_APP;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_CDFAMAPPUIOA" after delete
on OA.CD_FAM_APPUI_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.APPUIS_OA"
	delete OA.APPUIS_OA
	where CD_FAM_APPUI_OA__FAM_APP = :old.FAM_APP;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TUA_CDGESTOA" after update
of GESTIONNAIRE
on OA.CD_GEST_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.CD_GEST_OA" dans les enfants "OA.DSC_OA"
	if ((updating('GESTIONNAIRE') and :old.GESTIONNAIRE != :new.GESTIONNAIRE)) then 
		update OA.DSC_OA
		set CD_GEST_OA__GESTIONNAIRE = :new.GESTIONNAIRE  
		where CD_GEST_OA__GESTIONNAIRE = :old.GESTIONNAIRE;
	end if;
	--  Modification du code du parent "OA.CD_GEST_OA" dans les enfants "OA.DSC_TEMP_OA"
	if ((updating('GESTIONNAIRE') and :old.GESTIONNAIRE != :new.GESTIONNAIRE)) then 
		update OA.DSC_TEMP_OA
		set CD_GEST_OA__GESTIONNAIRE = :new.GESTIONNAIRE  
		where CD_GEST_OA__GESTIONNAIRE = :old.GESTIONNAIRE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_CDGESTOA" after delete
on OA.CD_GEST_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.DSC_OA"
	delete OA.DSC_OA
	where CD_GEST_OA__GESTIONNAIRE = :old.GESTIONNAIRE;
	
	--  Suppression des enfants dans "OA.DSC_TEMP_OA"
	delete OA.DSC_TEMP_OA
	where CD_GEST_OA__GESTIONNAIRE = :old.GESTIONNAIRE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TUA_GRPOA" after update
of ID_GRP
on OA.GRP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.GRP_OA" dans les enfants "OA.PRT_OA"
	if ((updating('ID_GRP') and :old.ID_GRP != :new.ID_GRP)) then 
		update OA.PRT_OA
		set GRP_OA__ID_GRP = :new.ID_GRP  
		where GRP_OA__ID_GRP = :old.ID_GRP;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_GRPOA" after delete
on OA.GRP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.PRT_OA"
	delete OA.PRT_OA
	where GRP_OA__ID_GRP = :old.ID_GRP;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TUA_CDHIERARCHIEOA" after update
of HIERARCHIE
on OA.CD_HIERARCHIE_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.CD_HIERARCHIE_OA" dans les enfants "OA.DSC_OA"
	if ((updating('HIERARCHIE') and :old.HIERARCHIE != :new.HIERARCHIE)) then 
		update OA.DSC_OA
		set CD_HIERARCHIE_OA__HIERARCHIE = :new.HIERARCHIE  
		where CD_HIERARCHIE_OA__HIERARCHIE = :old.HIERARCHIE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_CDHIERARCHIEOA" after delete
on OA.CD_HIERARCHIE_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.DSC_OA"
	delete OA.DSC_OA
	where CD_HIERARCHIE_OA__HIERARCHIE = :old.HIERARCHIE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TIB_HISTONOTEOA" before insert
on OA.HISTO_NOTE_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.DSC_OA"
	cursor c1_histo_note_oa(Vdsc_oa__num_oa varchar) is
		select 1 
		from OA.DSC_OA 
		where 
		NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_ORIGIN_OA"
	cursor c2_histo_note_oa(Vcd_origin_oa__origine varchar) is
		select 1 
		from OA.CD_ORIGIN_OA 
		where 
		ORIGINE = Vcd_origin_oa__origine and Vcd_origin_oa__origine is not null;
begin

	
	--  Le parent "OA.DSC_OA" doit exister à la création d'un enfant dans "OA.HISTO_NOTE_OA"
	if :new.DSC_OA__NUM_OA is not null then 
		open c1_histo_note_oa ( :new.DSC_OA__NUM_OA);
		fetch c1_histo_note_oa into dummy;
		found := c1_histo_note_oa%FOUND;
		close c1_histo_note_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.DSC_OA". Impossible de créer un enfant dans "OA.HISTO_NOTE_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_ORIGIN_OA" doit exister à la création d'un enfant dans "OA.HISTO_NOTE_OA"
	if :new.CD_ORIGIN_OA__ORIGINE is not null then 
		open c2_histo_note_oa ( :new.CD_ORIGIN_OA__ORIGINE);
		fetch c2_histo_note_oa into dummy;
		found := c2_histo_note_oa%FOUND;
		close c2_histo_note_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_ORIGIN_OA". Impossible de créer un enfant dans "OA.HISTO_NOTE_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_HISTONOTEOA" before update
on OA.HISTO_NOTE_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.DSC_OA"
	cursor c1_histo_note_oa (Vdsc_oa__num_oa varchar) is
		select 1 
		from OA.DSC_OA 
		where 
		NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_ORIGIN_OA"
	cursor c2_histo_note_oa (Vcd_origin_oa__origine varchar) is
		select 1 
		from OA.CD_ORIGIN_OA 
		where 
		ORIGINE = Vcd_origin_oa__origine and Vcd_origin_oa__origine is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.DSC_OA" doit exister à la création d'un enfant dans "OA.HISTO_NOTE_OA"
	if :new.DSC_OA__NUM_OA is not null and seq = 0 then 
		open c1_histo_note_oa ( :new.DSC_OA__NUM_OA);
		fetch c1_histo_note_oa into dummy;
		found := c1_histo_note_oa%FOUND;
		close c1_histo_note_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.DSC_OA". Impossible de modifier un enfant dans "OA.HISTO_NOTE_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_ORIGIN_OA" doit exister à la création d'un enfant dans "OA.HISTO_NOTE_OA"
	if :new.CD_ORIGIN_OA__ORIGINE is not null and seq = 0 then 
		open c2_histo_note_oa ( :new.CD_ORIGIN_OA__ORIGINE);
		fetch c2_histo_note_oa into dummy;
		found := c2_histo_note_oa%FOUND;
		close c2_histo_note_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_ORIGIN_OA". Impossible de modifier un enfant dans "OA.HISTO_NOTE_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TIB_DSCCAMPOA" before insert
on OA.DSC_CAMP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.DSC_OA"
	cursor c1_dsc_camp_oa(Vdsc_oa__num_oa varchar) is
		select 1 
		from OA.DSC_OA 
		where 
		NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CAMP_OA"
	cursor c2_dsc_camp_oa(Vcamp_oa__id_camp varchar) is
		select 1 
		from OA.CAMP_OA 
		where 
		ID_CAMP = Vcamp_oa__id_camp and Vcamp_oa__id_camp is not null;
begin

	
	--  Le parent "OA.DSC_OA" doit exister à la création d'un enfant dans "OA.DSC_CAMP_OA"
	if :new.DSC_OA__NUM_OA is not null then 
		open c1_dsc_camp_oa ( :new.DSC_OA__NUM_OA);
		fetch c1_dsc_camp_oa into dummy;
		found := c1_dsc_camp_oa%FOUND;
		close c1_dsc_camp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.DSC_OA". Impossible de créer un enfant dans "OA.DSC_CAMP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CAMP_OA" doit exister à la création d'un enfant dans "OA.DSC_CAMP_OA"
	if :new.CAMP_OA__ID_CAMP is not null then 
		open c2_dsc_camp_oa ( :new.CAMP_OA__ID_CAMP);
		fetch c2_dsc_camp_oa into dummy;
		found := c2_dsc_camp_oa%FOUND;
		close c2_dsc_camp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CAMP_OA". Impossible de créer un enfant dans "OA.DSC_CAMP_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_DSCCAMPOA" before update
on OA.DSC_CAMP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.DSC_OA"
	cursor c1_dsc_camp_oa (Vdsc_oa__num_oa varchar) is
		select 1 
		from OA.DSC_OA 
		where 
		NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CAMP_OA"
	cursor c2_dsc_camp_oa (Vcamp_oa__id_camp varchar) is
		select 1 
		from OA.CAMP_OA 
		where 
		ID_CAMP = Vcamp_oa__id_camp and Vcamp_oa__id_camp is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.DSC_OA" doit exister à la création d'un enfant dans "OA.DSC_CAMP_OA"
	if :new.DSC_OA__NUM_OA is not null and seq = 0 then 
		open c1_dsc_camp_oa ( :new.DSC_OA__NUM_OA);
		fetch c1_dsc_camp_oa into dummy;
		found := c1_dsc_camp_oa%FOUND;
		close c1_dsc_camp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.DSC_OA". Impossible de modifier un enfant dans "OA.DSC_CAMP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CAMP_OA" doit exister à la création d'un enfant dans "OA.DSC_CAMP_OA"
	if :new.CAMP_OA__ID_CAMP is not null and seq = 0 then 
		open c2_dsc_camp_oa ( :new.CAMP_OA__ID_CAMP);
		fetch c2_dsc_camp_oa into dummy;
		found := c2_dsc_camp_oa%FOUND;
		close c2_dsc_camp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CAMP_OA". Impossible de modifier un enfant dans "OA.DSC_CAMP_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TIB_INSPECTEUROA" before insert
on OA.INSPECTEUR_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_PRESTA_OA"
	cursor c1_inspecteur_oa(Vcd_presta_oa__prestataire varchar) is
		select 1 
		from OA.CD_PRESTA_OA 
		where 
		PRESTATAIRE = Vcd_presta_oa__prestataire and Vcd_presta_oa__prestataire is not null;
begin

	
	--  Le parent "OA.CD_PRESTA_OA" doit exister à la création d'un enfant dans "OA.INSPECTEUR_OA"
	if :new.CD_PRESTA_OA__PRESTATAIRE is not null then 
		open c1_inspecteur_oa ( :new.CD_PRESTA_OA__PRESTATAIRE);
		fetch c1_inspecteur_oa into dummy;
		found := c1_inspecteur_oa%FOUND;
		close c1_inspecteur_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_PRESTA_OA". Impossible de créer un enfant dans "OA.INSPECTEUR_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_INSPECTEUROA" before update
on OA.INSPECTEUR_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_PRESTA_OA"
	cursor c1_inspecteur_oa (Vcd_presta_oa__prestataire varchar) is
		select 1 
		from OA.CD_PRESTA_OA 
		where 
		PRESTATAIRE = Vcd_presta_oa__prestataire and Vcd_presta_oa__prestataire is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.CD_PRESTA_OA" doit exister à la création d'un enfant dans "OA.INSPECTEUR_OA"
	if :new.CD_PRESTA_OA__PRESTATAIRE is not null and seq = 0 then 
		open c1_inspecteur_oa ( :new.CD_PRESTA_OA__PRESTATAIRE);
		fetch c1_inspecteur_oa into dummy;
		found := c1_inspecteur_oa%FOUND;
		close c1_inspecteur_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_PRESTA_OA". Impossible de modifier un enfant dans "OA.INSPECTEUR_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUA_INSPECTEUROA" after update
of NOM
on OA.INSPECTEUR_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.INSPECTEUR_OA" dans les enfants "OA.INSP_OA"
	if ((updating('NOM') and :old.NOM != :new.NOM)) then 
		update OA.INSP_OA
		set INSPECTEUR_OA__NOM = :new.NOM  
		where INSPECTEUR_OA__NOM = :old.NOM;
	end if;
	--  Modification du code du parent "OA.INSPECTEUR_OA" dans les enfants "OA.VST_OA"
	if ((updating('NOM') and :old.NOM != :new.NOM)) then 
		update OA.VST_OA
		set INSPECTEUR_OA__NOM = :new.NOM  
		where INSPECTEUR_OA__NOM = :old.NOM;
	end if;
	--  Modification du code du parent "OA.INSPECTEUR_OA" dans les enfants "OA.INSP_TMP_OA"
	if ((updating('NOM') and :old.NOM != :new.NOM)) then 
		update OA.INSP_TMP_OA
		set INSPECTEUR_OA__NOM = :new.NOM  
		where INSPECTEUR_OA__NOM = :old.NOM;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_INSPECTEUROA" after delete
on OA.INSPECTEUR_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.INSP_OA"
	delete OA.INSP_OA
	where INSPECTEUR_OA__NOM = :old.NOM;
	
	--  Suppression des enfants dans "OA.VST_OA"
	delete OA.VST_OA
	where INSPECTEUR_OA__NOM = :old.NOM;
	
	--  Suppression des enfants dans "OA.INSP_TMP_OA"
	delete OA.INSP_TMP_OA
	where INSPECTEUR_OA__NOM = :old.NOM;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TIB_INSPOA" before insert
on OA.INSP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.DSC_OA"
	cursor c1_insp_oa(Vdsc_oa__num_oa varchar) is
		select 1 
		from OA.DSC_OA 
		where 
		NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_METEO_OA"
	cursor c2_insp_oa(Vcd_meteo_oa__meteo varchar) is
		select 1 
		from OA.CD_METEO_OA 
		where 
		METEO = Vcd_meteo_oa__meteo and Vcd_meteo_oa__meteo is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_ETUDE_OA"
	cursor c3_insp_oa(Vcd_etude_oa__etude varchar) is
		select 1 
		from OA.CD_ETUDE_OA 
		where 
		ETUDE = Vcd_etude_oa__etude and Vcd_etude_oa__etude is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_IQOA_OA"
	cursor c4_insp_oa(Vcd_iqoa_oa__note_iqoa varchar) is
		select 1 
		from OA.CD_IQOA_OA 
		where 
		NOTE_IQOA = Vcd_iqoa_oa__note_iqoa and Vcd_iqoa_oa__note_iqoa is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CAMP_OA"
	cursor c5_insp_oa(Vcamp_oa__id_camp varchar) is
		select 1 
		from OA.CAMP_OA 
		where 
		ID_CAMP = Vcamp_oa__id_camp and Vcamp_oa__id_camp is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.INSPECTEUR_OA"
	cursor c6_insp_oa(Vinspecteur_oa__nom varchar) is
		select 1 
		from OA.INSPECTEUR_OA 
		where 
		NOM = Vinspecteur_oa__nom and Vinspecteur_oa__nom is not null;
begin

	
	--  Le parent "OA.DSC_OA" doit exister à la création d'un enfant dans "OA.INSP_OA"
	if :new.DSC_OA__NUM_OA is not null then 
		open c1_insp_oa ( :new.DSC_OA__NUM_OA);
		fetch c1_insp_oa into dummy;
		found := c1_insp_oa%FOUND;
		close c1_insp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.DSC_OA". Impossible de créer un enfant dans "OA.INSP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_METEO_OA" doit exister à la création d'un enfant dans "OA.INSP_OA"
	if :new.CD_METEO_OA__METEO is not null then 
		open c2_insp_oa ( :new.CD_METEO_OA__METEO);
		fetch c2_insp_oa into dummy;
		found := c2_insp_oa%FOUND;
		close c2_insp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_METEO_OA". Impossible de créer un enfant dans "OA.INSP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_ETUDE_OA" doit exister à la création d'un enfant dans "OA.INSP_OA"
	if :new.CD_ETUDE_OA__ETUDE is not null then 
		open c3_insp_oa ( :new.CD_ETUDE_OA__ETUDE);
		fetch c3_insp_oa into dummy;
		found := c3_insp_oa%FOUND;
		close c3_insp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_ETUDE_OA". Impossible de créer un enfant dans "OA.INSP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_IQOA_OA" doit exister à la création d'un enfant dans "OA.INSP_OA"
	if :new.CD_IQOA_OA__NOTE_IQOA is not null then 
		open c4_insp_oa ( :new.CD_IQOA_OA__NOTE_IQOA);
		fetch c4_insp_oa into dummy;
		found := c4_insp_oa%FOUND;
		close c4_insp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_IQOA_OA". Impossible de créer un enfant dans "OA.INSP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CAMP_OA" doit exister à la création d'un enfant dans "OA.INSP_OA"
	if :new.CAMP_OA__ID_CAMP is not null then 
		open c5_insp_oa ( :new.CAMP_OA__ID_CAMP);
		fetch c5_insp_oa into dummy;
		found := c5_insp_oa%FOUND;
		close c5_insp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CAMP_OA". Impossible de créer un enfant dans "OA.INSP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.INSPECTEUR_OA" doit exister à la création d'un enfant dans "OA.INSP_OA"
	if :new.INSPECTEUR_OA__NOM is not null then 
		open c6_insp_oa ( :new.INSPECTEUR_OA__NOM);
		fetch c6_insp_oa into dummy;
		found := c6_insp_oa%FOUND;
		close c6_insp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.INSPECTEUR_OA". Impossible de créer un enfant dans "OA.INSP_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_INSPOA" before update
on OA.INSP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.DSC_OA"
	cursor c1_insp_oa (Vdsc_oa__num_oa varchar) is
		select 1 
		from OA.DSC_OA 
		where 
		NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_METEO_OA"
	cursor c2_insp_oa (Vcd_meteo_oa__meteo varchar) is
		select 1 
		from OA.CD_METEO_OA 
		where 
		METEO = Vcd_meteo_oa__meteo and Vcd_meteo_oa__meteo is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_ETUDE_OA"
	cursor c3_insp_oa (Vcd_etude_oa__etude varchar) is
		select 1 
		from OA.CD_ETUDE_OA 
		where 
		ETUDE = Vcd_etude_oa__etude and Vcd_etude_oa__etude is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_IQOA_OA"
	cursor c4_insp_oa (Vcd_iqoa_oa__note_iqoa varchar) is
		select 1 
		from OA.CD_IQOA_OA 
		where 
		NOTE_IQOA = Vcd_iqoa_oa__note_iqoa and Vcd_iqoa_oa__note_iqoa is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CAMP_OA"
	cursor c5_insp_oa (Vcamp_oa__id_camp varchar) is
		select 1 
		from OA.CAMP_OA 
		where 
		ID_CAMP = Vcamp_oa__id_camp and Vcamp_oa__id_camp is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.INSPECTEUR_OA"
	cursor c6_insp_oa (Vinspecteur_oa__nom varchar) is
		select 1 
		from OA.INSPECTEUR_OA 
		where 
		NOM = Vinspecteur_oa__nom and Vinspecteur_oa__nom is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.DSC_OA" doit exister à la création d'un enfant dans "OA.INSP_OA"
	if :new.DSC_OA__NUM_OA is not null and seq = 0 then 
		open c1_insp_oa ( :new.DSC_OA__NUM_OA);
		fetch c1_insp_oa into dummy;
		found := c1_insp_oa%FOUND;
		close c1_insp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.DSC_OA". Impossible de modifier un enfant dans "OA.INSP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_METEO_OA" doit exister à la création d'un enfant dans "OA.INSP_OA"
	if :new.CD_METEO_OA__METEO is not null and seq = 0 then 
		open c2_insp_oa ( :new.CD_METEO_OA__METEO);
		fetch c2_insp_oa into dummy;
		found := c2_insp_oa%FOUND;
		close c2_insp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_METEO_OA". Impossible de modifier un enfant dans "OA.INSP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_ETUDE_OA" doit exister à la création d'un enfant dans "OA.INSP_OA"
	if :new.CD_ETUDE_OA__ETUDE is not null and seq = 0 then 
		open c3_insp_oa ( :new.CD_ETUDE_OA__ETUDE);
		fetch c3_insp_oa into dummy;
		found := c3_insp_oa%FOUND;
		close c3_insp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_ETUDE_OA". Impossible de modifier un enfant dans "OA.INSP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_IQOA_OA" doit exister à la création d'un enfant dans "OA.INSP_OA"
	if :new.CD_IQOA_OA__NOTE_IQOA is not null and seq = 0 then 
		open c4_insp_oa ( :new.CD_IQOA_OA__NOTE_IQOA);
		fetch c4_insp_oa into dummy;
		found := c4_insp_oa%FOUND;
		close c4_insp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_IQOA_OA". Impossible de modifier un enfant dans "OA.INSP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CAMP_OA" doit exister à la création d'un enfant dans "OA.INSP_OA"
	if :new.CAMP_OA__ID_CAMP is not null and seq = 0 then 
		open c5_insp_oa ( :new.CAMP_OA__ID_CAMP);
		fetch c5_insp_oa into dummy;
		found := c5_insp_oa%FOUND;
		close c5_insp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CAMP_OA". Impossible de modifier un enfant dans "OA.INSP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.INSPECTEUR_OA" doit exister à la création d'un enfant dans "OA.INSP_OA"
	if :new.INSPECTEUR_OA__NOM is not null and seq = 0 then 
		open c6_insp_oa ( :new.INSPECTEUR_OA__NOM);
		fetch c6_insp_oa into dummy;
		found := c6_insp_oa%FOUND;
		close c6_insp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.INSPECTEUR_OA". Impossible de modifier un enfant dans "OA.INSP_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUA_INSPOA" after update
of DSC_OA__NUM_OA,CAMP_OA__ID_CAMP
on OA.INSP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.INSP_OA" dans les enfants "OA.ELT_INSP_OA"
	if ((updating('DSC_OA__NUM_OA') and :old.DSC_OA__NUM_OA != :new.DSC_OA__NUM_OA) or 
	(updating('CAMP_OA__ID_CAMP') and :old.CAMP_OA__ID_CAMP != :new.CAMP_OA__ID_CAMP)) then 
		update OA.ELT_INSP_OA
		set DSC_OA__NUM_OA = :new.DSC_OA__NUM_OA,
		CAMP_OA__ID_CAMP = :new.CAMP_OA__ID_CAMP  
		where DSC_OA__NUM_OA = :old.DSC_OA__NUM_OA and 
		CAMP_OA__ID_CAMP = :old.CAMP_OA__ID_CAMP;
	end if;
	--  Modification du code du parent "OA.INSP_OA" dans les enfants "OA.PHOTO_INSP_OA"
	if ((updating('DSC_OA__NUM_OA') and :old.DSC_OA__NUM_OA != :new.DSC_OA__NUM_OA) or 
	(updating('CAMP_OA__ID_CAMP') and :old.CAMP_OA__ID_CAMP != :new.CAMP_OA__ID_CAMP)) then 
		update OA.PHOTO_INSP_OA
		set DSC_OA__NUM_OA = :new.DSC_OA__NUM_OA,
		CAMP_OA__ID_CAMP = :new.CAMP_OA__ID_CAMP  
		where DSC_OA__NUM_OA = :old.DSC_OA__NUM_OA and 
		CAMP_OA__ID_CAMP = :old.CAMP_OA__ID_CAMP;
	end if;
	--  Modification du code du parent "OA.INSP_OA" dans les enfants "OA.CD_CONCLUSION__INSP_OA"
	if ((updating('DSC_OA__NUM_OA') and :old.DSC_OA__NUM_OA != :new.DSC_OA__NUM_OA) or 
	(updating('CAMP_OA__ID_CAMP') and :old.CAMP_OA__ID_CAMP != :new.CAMP_OA__ID_CAMP)) then 
		update OA.CD_CONCLUSION__INSP_OA
		set DSC_OA__NUM_OA = :new.DSC_OA__NUM_OA,
		CAMP_OA__ID_CAMP = :new.CAMP_OA__ID_CAMP  
		where DSC_OA__NUM_OA = :old.DSC_OA__NUM_OA and 
		CAMP_OA__ID_CAMP = :old.CAMP_OA__ID_CAMP;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_INSPOA" after delete
on OA.INSP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.ELT_INSP_OA"
	delete OA.ELT_INSP_OA
	where DSC_OA__NUM_OA = :old.DSC_OA__NUM_OA and 
	CAMP_OA__ID_CAMP = :old.CAMP_OA__ID_CAMP;
	
	--  Suppression des enfants dans "OA.PHOTO_INSP_OA"
	delete OA.PHOTO_INSP_OA
	where DSC_OA__NUM_OA = :old.DSC_OA__NUM_OA and 
	CAMP_OA__ID_CAMP = :old.CAMP_OA__ID_CAMP;
	
	--  Suppression des enfants dans "OA.CD_CONCLUSION__INSP_OA"
	delete OA.CD_CONCLUSION__INSP_OA
	where DSC_OA__NUM_OA = :old.DSC_OA__NUM_OA and 
	CAMP_OA__ID_CAMP = :old.CAMP_OA__ID_CAMP;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TIB_INSPTMPOA" before insert
on OA.INSP_TMP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_ETUDE_OA"
	cursor c1_insp_tmp_oa(Vcd_etude_oa__etude varchar) is
		select 1 
		from OA.CD_ETUDE_OA 
		where 
		ETUDE = Vcd_etude_oa__etude and Vcd_etude_oa__etude is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_METEO_OA"
	cursor c2_insp_tmp_oa(Vcd_meteo_oa__meteo varchar) is
		select 1 
		from OA.CD_METEO_OA 
		where 
		METEO = Vcd_meteo_oa__meteo and Vcd_meteo_oa__meteo is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_IQOA_OA"
	cursor c3_insp_tmp_oa(Vcd_iqoa_oa__note_iqoa varchar) is
		select 1 
		from OA.CD_IQOA_OA 
		where 
		NOTE_IQOA = Vcd_iqoa_oa__note_iqoa and Vcd_iqoa_oa__note_iqoa is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.DSC_TEMP_OA"
	cursor c4_insp_tmp_oa(Vcamp_oa__id_camp varchar,
	Vdsc_temp_oa__num_oa varchar) is
		select 1 
		from OA.DSC_TEMP_OA 
		where 
		CAMP_OA__ID_CAMP = Vcamp_oa__id_camp and Vcamp_oa__id_camp is not null and 
		NUM_OA = Vdsc_temp_oa__num_oa and Vdsc_temp_oa__num_oa is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.INSPECTEUR_OA"
	cursor c5_insp_tmp_oa(Vinspecteur_oa__nom varchar) is
		select 1 
		from OA.INSPECTEUR_OA 
		where 
		NOM = Vinspecteur_oa__nom and Vinspecteur_oa__nom is not null;
begin

	
	--  Le parent "OA.CD_ETUDE_OA" doit exister à la création d'un enfant dans "OA.INSP_TMP_OA"
	if :new.CD_ETUDE_OA__ETUDE is not null then 
		open c1_insp_tmp_oa ( :new.CD_ETUDE_OA__ETUDE);
		fetch c1_insp_tmp_oa into dummy;
		found := c1_insp_tmp_oa%FOUND;
		close c1_insp_tmp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_ETUDE_OA". Impossible de créer un enfant dans "OA.INSP_TMP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_METEO_OA" doit exister à la création d'un enfant dans "OA.INSP_TMP_OA"
	if :new.CD_METEO_OA__METEO is not null then 
		open c2_insp_tmp_oa ( :new.CD_METEO_OA__METEO);
		fetch c2_insp_tmp_oa into dummy;
		found := c2_insp_tmp_oa%FOUND;
		close c2_insp_tmp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_METEO_OA". Impossible de créer un enfant dans "OA.INSP_TMP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_IQOA_OA" doit exister à la création d'un enfant dans "OA.INSP_TMP_OA"
	if :new.CD_IQOA_OA__NOTE_IQOA is not null then 
		open c3_insp_tmp_oa ( :new.CD_IQOA_OA__NOTE_IQOA);
		fetch c3_insp_tmp_oa into dummy;
		found := c3_insp_tmp_oa%FOUND;
		close c3_insp_tmp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_IQOA_OA". Impossible de créer un enfant dans "OA.INSP_TMP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.DSC_TEMP_OA" doit exister à la création d'un enfant dans "OA.INSP_TMP_OA"
	if :new.CAMP_OA__ID_CAMP is not null and 
	:new.DSC_TEMP_OA__NUM_OA is not null then 
		open c4_insp_tmp_oa ( :new.CAMP_OA__ID_CAMP,
		:new.DSC_TEMP_OA__NUM_OA);
		fetch c4_insp_tmp_oa into dummy;
		found := c4_insp_tmp_oa%FOUND;
		close c4_insp_tmp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.DSC_TEMP_OA". Impossible de créer un enfant dans "OA.INSP_TMP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.INSPECTEUR_OA" doit exister à la création d'un enfant dans "OA.INSP_TMP_OA"
	if :new.INSPECTEUR_OA__NOM is not null then 
		open c5_insp_tmp_oa ( :new.INSPECTEUR_OA__NOM);
		fetch c5_insp_tmp_oa into dummy;
		found := c5_insp_tmp_oa%FOUND;
		close c5_insp_tmp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.INSPECTEUR_OA". Impossible de créer un enfant dans "OA.INSP_TMP_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_INSPTMPOA" before update
on OA.INSP_TMP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_ETUDE_OA"
	cursor c1_insp_tmp_oa (Vcd_etude_oa__etude varchar) is
		select 1 
		from OA.CD_ETUDE_OA 
		where 
		ETUDE = Vcd_etude_oa__etude and Vcd_etude_oa__etude is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_METEO_OA"
	cursor c2_insp_tmp_oa (Vcd_meteo_oa__meteo varchar) is
		select 1 
		from OA.CD_METEO_OA 
		where 
		METEO = Vcd_meteo_oa__meteo and Vcd_meteo_oa__meteo is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_IQOA_OA"
	cursor c3_insp_tmp_oa (Vcd_iqoa_oa__note_iqoa varchar) is
		select 1 
		from OA.CD_IQOA_OA 
		where 
		NOTE_IQOA = Vcd_iqoa_oa__note_iqoa and Vcd_iqoa_oa__note_iqoa is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.DSC_TEMP_OA"
	cursor c4_insp_tmp_oa (Vcamp_oa__id_camp varchar,
	Vdsc_temp_oa__num_oa varchar) is
		select 1 
		from OA.DSC_TEMP_OA 
		where 
		CAMP_OA__ID_CAMP = Vcamp_oa__id_camp and Vcamp_oa__id_camp is not null and 
		NUM_OA = Vdsc_temp_oa__num_oa and Vdsc_temp_oa__num_oa is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.INSPECTEUR_OA"
	cursor c5_insp_tmp_oa (Vinspecteur_oa__nom varchar) is
		select 1 
		from OA.INSPECTEUR_OA 
		where 
		NOM = Vinspecteur_oa__nom and Vinspecteur_oa__nom is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.CD_ETUDE_OA" doit exister à la création d'un enfant dans "OA.INSP_TMP_OA"
	if :new.CD_ETUDE_OA__ETUDE is not null and seq = 0 then 
		open c1_insp_tmp_oa ( :new.CD_ETUDE_OA__ETUDE);
		fetch c1_insp_tmp_oa into dummy;
		found := c1_insp_tmp_oa%FOUND;
		close c1_insp_tmp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_ETUDE_OA". Impossible de modifier un enfant dans "OA.INSP_TMP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_METEO_OA" doit exister à la création d'un enfant dans "OA.INSP_TMP_OA"
	if :new.CD_METEO_OA__METEO is not null and seq = 0 then 
		open c2_insp_tmp_oa ( :new.CD_METEO_OA__METEO);
		fetch c2_insp_tmp_oa into dummy;
		found := c2_insp_tmp_oa%FOUND;
		close c2_insp_tmp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_METEO_OA". Impossible de modifier un enfant dans "OA.INSP_TMP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_IQOA_OA" doit exister à la création d'un enfant dans "OA.INSP_TMP_OA"
	if :new.CD_IQOA_OA__NOTE_IQOA is not null and seq = 0 then 
		open c3_insp_tmp_oa ( :new.CD_IQOA_OA__NOTE_IQOA);
		fetch c3_insp_tmp_oa into dummy;
		found := c3_insp_tmp_oa%FOUND;
		close c3_insp_tmp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_IQOA_OA". Impossible de modifier un enfant dans "OA.INSP_TMP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.DSC_TEMP_OA" doit exister à la création d'un enfant dans "OA.INSP_TMP_OA"
	if :new.CAMP_OA__ID_CAMP is not null and seq = 0 and 
	:new.DSC_TEMP_OA__NUM_OA is not null and seq = 0 then 
		open c4_insp_tmp_oa ( :new.CAMP_OA__ID_CAMP,
		:new.DSC_TEMP_OA__NUM_OA);
		fetch c4_insp_tmp_oa into dummy;
		found := c4_insp_tmp_oa%FOUND;
		close c4_insp_tmp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.DSC_TEMP_OA". Impossible de modifier un enfant dans "OA.INSP_TMP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.INSPECTEUR_OA" doit exister à la création d'un enfant dans "OA.INSP_TMP_OA"
	if :new.INSPECTEUR_OA__NOM is not null and seq = 0 then 
		open c5_insp_tmp_oa ( :new.INSPECTEUR_OA__NOM);
		fetch c5_insp_tmp_oa into dummy;
		found := c5_insp_tmp_oa%FOUND;
		close c5_insp_tmp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.INSPECTEUR_OA". Impossible de modifier un enfant dans "OA.INSP_TMP_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUA_INSPTMPOA" after update
of CAMP_OA__ID_CAMP,DSC_TEMP_OA__NUM_OA
on OA.INSP_TMP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.INSP_TMP_OA" dans les enfants "OA.ELT_INSP_TMP_OA"
	if ((updating('CAMP_OA__ID_CAMP') and :old.CAMP_OA__ID_CAMP != :new.CAMP_OA__ID_CAMP) or 
	(updating('DSC_TEMP_OA__NUM_OA') and :old.DSC_TEMP_OA__NUM_OA != :new.DSC_TEMP_OA__NUM_OA)) then 
		update OA.ELT_INSP_TMP_OA
		set CAMP_OA__ID_CAMP = :new.CAMP_OA__ID_CAMP,
		DSC_TEMP_OA__NUM_OA = :new.DSC_TEMP_OA__NUM_OA  
		where CAMP_OA__ID_CAMP = :old.CAMP_OA__ID_CAMP and 
		DSC_TEMP_OA__NUM_OA = :old.DSC_TEMP_OA__NUM_OA;
	end if;
	--  Modification du code du parent "OA.INSP_TMP_OA" dans les enfants "OA.PHOTO_INSP_TMP_OA"
	if ((updating('CAMP_OA__ID_CAMP') and :old.CAMP_OA__ID_CAMP != :new.CAMP_OA__ID_CAMP) or 
	(updating('DSC_TEMP_OA__NUM_OA') and :old.DSC_TEMP_OA__NUM_OA != :new.DSC_TEMP_OA__NUM_OA)) then 
		update OA.PHOTO_INSP_TMP_OA
		set CAMP_OA__ID_CAMP = :new.CAMP_OA__ID_CAMP,
		DSC_TEMP_OA__NUM_OA = :new.DSC_TEMP_OA__NUM_OA  
		where CAMP_OA__ID_CAMP = :old.CAMP_OA__ID_CAMP and 
		DSC_TEMP_OA__NUM_OA = :old.DSC_TEMP_OA__NUM_OA;
	end if;
	--  Modification du code du parent "OA.INSP_TMP_OA" dans les enfants "OA.CD_CONCLUSION__INSP_TMP_OA"
	if ((updating('CAMP_OA__ID_CAMP') and :old.CAMP_OA__ID_CAMP != :new.CAMP_OA__ID_CAMP) or 
	(updating('DSC_TEMP_OA__NUM_OA') and :old.DSC_TEMP_OA__NUM_OA != :new.DSC_TEMP_OA__NUM_OA)) then 
		update OA.CD_CONCLUSION__INSP_TMP_OA
		set CAMP_OA__ID_CAMP = :new.CAMP_OA__ID_CAMP,
		DSC_TEMP_OA__NUM_OA = :new.DSC_TEMP_OA__NUM_OA  
		where CAMP_OA__ID_CAMP = :old.CAMP_OA__ID_CAMP and 
		DSC_TEMP_OA__NUM_OA = :old.DSC_TEMP_OA__NUM_OA;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_INSPTMPOA" after delete
on OA.INSP_TMP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.ELT_INSP_TMP_OA"
	delete OA.ELT_INSP_TMP_OA
	where CAMP_OA__ID_CAMP = :old.CAMP_OA__ID_CAMP and 
	DSC_TEMP_OA__NUM_OA = :old.DSC_TEMP_OA__NUM_OA;
	
	--  Suppression des enfants dans "OA.PHOTO_INSP_TMP_OA"
	delete OA.PHOTO_INSP_TMP_OA
	where CAMP_OA__ID_CAMP = :old.CAMP_OA__ID_CAMP and 
	DSC_TEMP_OA__NUM_OA = :old.DSC_TEMP_OA__NUM_OA;
	
	--  Suppression des enfants dans "OA.CD_CONCLUSION__INSP_TMP_OA"
	delete OA.CD_CONCLUSION__INSP_TMP_OA
	where CAMP_OA__ID_CAMP = :old.CAMP_OA__ID_CAMP and 
	DSC_TEMP_OA__NUM_OA = :old.DSC_TEMP_OA__NUM_OA;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TIB_JOINTOA" before insert
on OA.JOINT_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.TABLIER_OA"
	cursor c1_joint_oa(Vdsc_oa__num_oa varchar,
	Vtablier_oa__num_tab number) is
		select 1 
		from OA.TABLIER_OA 
		where 
		DSC_OA__NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null and 
		NUM_TAB = Vtablier_oa__num_tab and Vtablier_oa__num_tab is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_JOINT_OA"
	cursor c2_joint_oa(Vcd_joint_oa__type varchar) is
		select 1 
		from OA.CD_JOINT_OA 
		where 
		TYPE = Vcd_joint_oa__type and Vcd_joint_oa__type is not null;
begin

	
	--  Le parent "OA.TABLIER_OA" doit exister à la création d'un enfant dans "OA.JOINT_OA"
	if :new.DSC_OA__NUM_OA is not null and 
	:new.TABLIER_OA__NUM_TAB is not null then 
		open c1_joint_oa ( :new.DSC_OA__NUM_OA,
		:new.TABLIER_OA__NUM_TAB);
		fetch c1_joint_oa into dummy;
		found := c1_joint_oa%FOUND;
		close c1_joint_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.TABLIER_OA". Impossible de créer un enfant dans "OA.JOINT_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_JOINT_OA" doit exister à la création d'un enfant dans "OA.JOINT_OA"
	if :new.CD_JOINT_OA__TYPE is not null then 
		open c2_joint_oa ( :new.CD_JOINT_OA__TYPE);
		fetch c2_joint_oa into dummy;
		found := c2_joint_oa%FOUND;
		close c2_joint_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_JOINT_OA". Impossible de créer un enfant dans "OA.JOINT_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_JOINTOA" before update
on OA.JOINT_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.TABLIER_OA"
	cursor c1_joint_oa (Vdsc_oa__num_oa varchar,
	Vtablier_oa__num_tab number) is
		select 1 
		from OA.TABLIER_OA 
		where 
		DSC_OA__NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null and 
		NUM_TAB = Vtablier_oa__num_tab and Vtablier_oa__num_tab is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_JOINT_OA"
	cursor c2_joint_oa (Vcd_joint_oa__type varchar) is
		select 1 
		from OA.CD_JOINT_OA 
		where 
		TYPE = Vcd_joint_oa__type and Vcd_joint_oa__type is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.TABLIER_OA" doit exister à la création d'un enfant dans "OA.JOINT_OA"
	if :new.DSC_OA__NUM_OA is not null and seq = 0 and 
	:new.TABLIER_OA__NUM_TAB is not null and seq = 0 then 
		open c1_joint_oa ( :new.DSC_OA__NUM_OA,
		:new.TABLIER_OA__NUM_TAB);
		fetch c1_joint_oa into dummy;
		found := c1_joint_oa%FOUND;
		close c1_joint_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.TABLIER_OA". Impossible de modifier un enfant dans "OA.JOINT_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_JOINT_OA" doit exister à la création d'un enfant dans "OA.JOINT_OA"
	if :new.CD_JOINT_OA__TYPE is not null and seq = 0 then 
		open c2_joint_oa ( :new.CD_JOINT_OA__TYPE);
		fetch c2_joint_oa into dummy;
		found := c2_joint_oa%FOUND;
		close c2_joint_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_JOINT_OA". Impossible de modifier un enfant dans "OA.JOINT_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TIB_CDLIGNEOA" before insert
on OA.CD_LIGNE_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_CHAPITRE_OA"
	cursor c1_cd_ligne_oa(Vcd_chapitre_oa__id_chap number) is
		select 1 
		from OA.CD_CHAPITRE_OA 
		where 
		ID_CHAP = Vcd_chapitre_oa__id_chap and Vcd_chapitre_oa__id_chap is not null;
begin

	
	--  Le parent "OA.CD_CHAPITRE_OA" doit exister à la création d'un enfant dans "OA.CD_LIGNE_OA"
	if :new.CD_CHAPITRE_OA__ID_CHAP is not null then 
		open c1_cd_ligne_oa ( :new.CD_CHAPITRE_OA__ID_CHAP);
		fetch c1_cd_ligne_oa into dummy;
		found := c1_cd_ligne_oa%FOUND;
		close c1_cd_ligne_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_CHAPITRE_OA". Impossible de créer un enfant dans "OA.CD_LIGNE_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_CDLIGNEOA" before update
on OA.CD_LIGNE_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_CHAPITRE_OA"
	cursor c1_cd_ligne_oa (Vcd_chapitre_oa__id_chap number) is
		select 1 
		from OA.CD_CHAPITRE_OA 
		where 
		ID_CHAP = Vcd_chapitre_oa__id_chap and Vcd_chapitre_oa__id_chap is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.CD_CHAPITRE_OA" doit exister à la création d'un enfant dans "OA.CD_LIGNE_OA"
	if :new.CD_CHAPITRE_OA__ID_CHAP is not null and seq = 0 then 
		open c1_cd_ligne_oa ( :new.CD_CHAPITRE_OA__ID_CHAP);
		fetch c1_cd_ligne_oa into dummy;
		found := c1_cd_ligne_oa%FOUND;
		close c1_cd_ligne_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_CHAPITRE_OA". Impossible de modifier un enfant dans "OA.CD_LIGNE_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUA_CDLIGNEOA" after update
of CD_CHAPITRE_OA__ID_CHAP,ID_LIGNE
on OA.CD_LIGNE_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.CD_LIGNE_OA" dans les enfants "OA.SPRT_VST_OA"
	if ((updating('CD_CHAPITRE_OA__ID_CHAP') and :old.CD_CHAPITRE_OA__ID_CHAP != :new.CD_CHAPITRE_OA__ID_CHAP) or 
	(updating('ID_LIGNE') and :old.ID_LIGNE != :new.ID_LIGNE)) then 
		update OA.SPRT_VST_OA
		set CD_CHAPITRE_OA__ID_CHAP = :new.CD_CHAPITRE_OA__ID_CHAP,
		CD_LIGNE_OA__ID_LIGNE = :new.ID_LIGNE  
		where CD_CHAPITRE_OA__ID_CHAP = :old.CD_CHAPITRE_OA__ID_CHAP and 
		CD_LIGNE_OA__ID_LIGNE = :old.ID_LIGNE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_CDLIGNEOA" after delete
on OA.CD_LIGNE_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.SPRT_VST_OA"
	delete OA.SPRT_VST_OA
	where CD_CHAPITRE_OA__ID_CHAP = :old.CD_CHAPITRE_OA__ID_CHAP and 
	CD_LIGNE_OA__ID_LIGNE = :old.ID_LIGNE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TUA_CDMOOA" after update
of MAITRE_OUVR
on OA.CD_MO_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.CD_MO_OA" dans les enfants "OA.DSC_OA"
	if ((updating('MAITRE_OUVR') and :old.MAITRE_OUVR != :new.MAITRE_OUVR)) then 
		update OA.DSC_OA
		set CD_MO_OA__MAITRE_OUVR = :new.MAITRE_OUVR  
		where CD_MO_OA__MAITRE_OUVR = :old.MAITRE_OUVR;
	end if;
	--  Modification du code du parent "OA.CD_MO_OA" dans les enfants "OA.DSC_TEMP_OA"
	if ((updating('MAITRE_OUVR') and :old.MAITRE_OUVR != :new.MAITRE_OUVR)) then 
		update OA.DSC_TEMP_OA
		set CD_MO_OA__MAITRE_OUVR = :new.MAITRE_OUVR  
		where CD_MO_OA__MAITRE_OUVR = :old.MAITRE_OUVR;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_CDMOOA" after delete
on OA.CD_MO_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.DSC_OA"
	delete OA.DSC_OA
	where CD_MO_OA__MAITRE_OUVR = :old.MAITRE_OUVR;
	
	--  Suppression des enfants dans "OA.DSC_TEMP_OA"
	delete OA.DSC_TEMP_OA
	where CD_MO_OA__MAITRE_OUVR = :old.MAITRE_OUVR;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TUA_CDMATOA" after update
of MATERIAUX
on OA.CD_MAT_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.CD_MAT_OA" dans les enfants "OA.DSC_OA"
	if ((updating('MATERIAUX') and :old.MATERIAUX != :new.MATERIAUX)) then 
		update OA.DSC_OA
		set CD_MAT_OA__MATERIAUX = :new.MATERIAUX  
		where CD_MAT_OA__MATERIAUX = :old.MATERIAUX;
	end if;
	--  Modification du code du parent "OA.CD_MAT_OA" dans les enfants "OA.DSC_TEMP_OA"
	if ((updating('MATERIAUX') and :old.MATERIAUX != :new.MATERIAUX)) then 
		update OA.DSC_TEMP_OA
		set CD_MAT_OA__MATERIAUX = :new.MATERIAUX  
		where CD_MAT_OA__MATERIAUX = :old.MATERIAUX;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_CDMATOA" after delete
on OA.CD_MAT_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.DSC_OA"
	delete OA.DSC_OA
	where CD_MAT_OA__MATERIAUX = :old.MATERIAUX;
	
	--  Suppression des enfants dans "OA.DSC_TEMP_OA"
	delete OA.DSC_TEMP_OA
	where CD_MAT_OA__MATERIAUX = :old.MATERIAUX;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TUA_CDMETEOOA" after update
of METEO
on OA.CD_METEO_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.CD_METEO_OA" dans les enfants "OA.INSP_OA"
	if ((updating('METEO') and :old.METEO != :new.METEO)) then 
		update OA.INSP_OA
		set CD_METEO_OA__METEO = :new.METEO  
		where CD_METEO_OA__METEO = :old.METEO;
	end if;
	--  Modification du code du parent "OA.CD_METEO_OA" dans les enfants "OA.INSP_TMP_OA"
	if ((updating('METEO') and :old.METEO != :new.METEO)) then 
		update OA.INSP_TMP_OA
		set CD_METEO_OA__METEO = :new.METEO  
		where CD_METEO_OA__METEO = :old.METEO;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_CDMETEOOA" after delete
on OA.CD_METEO_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.INSP_OA"
	delete OA.INSP_OA
	where CD_METEO_OA__METEO = :old.METEO;
	
	--  Suppression des enfants dans "OA.INSP_TMP_OA"
	delete OA.INSP_TMP_OA
	where CD_METEO_OA__METEO = :old.METEO;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TIB_NATURETRAVOA" before insert
on OA.NATURE_TRAV_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_TRAVAUX_OA"
	cursor c1_nature_trav_oa(Vcd_travaux_oa__code varchar) is
		select 1 
		from OA.CD_TRAVAUX_OA 
		where 
		CODE = Vcd_travaux_oa__code and Vcd_travaux_oa__code is not null;
begin

	
	--  Le parent "OA.CD_TRAVAUX_OA" doit exister à la création d'un enfant dans "OA.NATURE_TRAV_OA"
	if :new.CD_TRAVAUX_OA__CODE is not null then 
		open c1_nature_trav_oa ( :new.CD_TRAVAUX_OA__CODE);
		fetch c1_nature_trav_oa into dummy;
		found := c1_nature_trav_oa%FOUND;
		close c1_nature_trav_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_TRAVAUX_OA". Impossible de créer un enfant dans "OA.NATURE_TRAV_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_NATURETRAVOA" before update
on OA.NATURE_TRAV_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_TRAVAUX_OA"
	cursor c1_nature_trav_oa (Vcd_travaux_oa__code varchar) is
		select 1 
		from OA.CD_TRAVAUX_OA 
		where 
		CODE = Vcd_travaux_oa__code and Vcd_travaux_oa__code is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.CD_TRAVAUX_OA" doit exister à la création d'un enfant dans "OA.NATURE_TRAV_OA"
	if :new.CD_TRAVAUX_OA__CODE is not null and seq = 0 then 
		open c1_nature_trav_oa ( :new.CD_TRAVAUX_OA__CODE);
		fetch c1_nature_trav_oa into dummy;
		found := c1_nature_trav_oa%FOUND;
		close c1_nature_trav_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_TRAVAUX_OA". Impossible de modifier un enfant dans "OA.NATURE_TRAV_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUA_NATURETRAVOA" after update
of CD_TRAVAUX_OA__CODE,NATURE
on OA.NATURE_TRAV_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.NATURE_TRAV_OA" dans les enfants "OA.TRAVAUX_OA"
	if ((updating('CD_TRAVAUX_OA__CODE') and :old.CD_TRAVAUX_OA__CODE != :new.CD_TRAVAUX_OA__CODE) or 
	(updating('NATURE') and :old.NATURE != :new.NATURE)) then 
		update OA.TRAVAUX_OA
		set CD_TRAVAUX_OA__CODE = :new.CD_TRAVAUX_OA__CODE,
		NATURE_TRAV_OA__NATURE = :new.NATURE  
		where CD_TRAVAUX_OA__CODE = :old.CD_TRAVAUX_OA__CODE and 
		NATURE_TRAV_OA__NATURE = :old.NATURE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_NATURETRAVOA" after delete
on OA.NATURE_TRAV_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.TRAVAUX_OA"
	delete OA.TRAVAUX_OA
	where CD_TRAVAUX_OA__CODE = :old.CD_TRAVAUX_OA__CODE and 
	NATURE_TRAV_OA__NATURE = :old.NATURE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TUA_CDOCCUPANTOA" after update
of NOM
on OA.CD_OCCUPANT_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.CD_OCCUPANT_OA" dans les enfants "OA.OCCUPATION_OA"
	if ((updating('NOM') and :old.NOM != :new.NOM)) then 
		update OA.OCCUPATION_OA
		set CD_OCCUPANT_OA__NOM = :new.NOM  
		where CD_OCCUPANT_OA__NOM = :old.NOM;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_CDOCCUPANTOA" after delete
on OA.CD_OCCUPANT_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.OCCUPATION_OA"
	delete OA.OCCUPATION_OA
	where CD_OCCUPANT_OA__NOM = :old.NOM;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TIB_OCCUPATIONOA" before insert
on OA.OCCUPATION_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.DSC_OA"
	cursor c1_occupation_oa(Vdsc_oa__num_oa varchar) is
		select 1 
		from OA.DSC_OA 
		where 
		NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_OCCUPANT_OA"
	cursor c2_occupation_oa(Vcd_occupant_oa__nom varchar) is
		select 1 
		from OA.CD_OCCUPANT_OA 
		where 
		NOM = Vcd_occupant_oa__nom and Vcd_occupant_oa__nom is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_OCCUP_OA"
	cursor c3_occupation_oa(Vcd_occup_oa__type varchar) is
		select 1 
		from OA.CD_OCCUP_OA 
		where 
		TYPE = Vcd_occup_oa__type and Vcd_occup_oa__type is not null;
begin

	
	--  Le parent "OA.DSC_OA" doit exister à la création d'un enfant dans "OA.OCCUPATION_OA"
	if :new.DSC_OA__NUM_OA is not null then 
		open c1_occupation_oa ( :new.DSC_OA__NUM_OA);
		fetch c1_occupation_oa into dummy;
		found := c1_occupation_oa%FOUND;
		close c1_occupation_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.DSC_OA". Impossible de créer un enfant dans "OA.OCCUPATION_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_OCCUPANT_OA" doit exister à la création d'un enfant dans "OA.OCCUPATION_OA"
	if :new.CD_OCCUPANT_OA__NOM is not null then 
		open c2_occupation_oa ( :new.CD_OCCUPANT_OA__NOM);
		fetch c2_occupation_oa into dummy;
		found := c2_occupation_oa%FOUND;
		close c2_occupation_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_OCCUPANT_OA". Impossible de créer un enfant dans "OA.OCCUPATION_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_OCCUP_OA" doit exister à la création d'un enfant dans "OA.OCCUPATION_OA"
	if :new.CD_OCCUP_OA__TYPE is not null then 
		open c3_occupation_oa ( :new.CD_OCCUP_OA__TYPE);
		fetch c3_occupation_oa into dummy;
		found := c3_occupation_oa%FOUND;
		close c3_occupation_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_OCCUP_OA". Impossible de créer un enfant dans "OA.OCCUPATION_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_OCCUPATIONOA" before update
on OA.OCCUPATION_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.DSC_OA"
	cursor c1_occupation_oa (Vdsc_oa__num_oa varchar) is
		select 1 
		from OA.DSC_OA 
		where 
		NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_OCCUPANT_OA"
	cursor c2_occupation_oa (Vcd_occupant_oa__nom varchar) is
		select 1 
		from OA.CD_OCCUPANT_OA 
		where 
		NOM = Vcd_occupant_oa__nom and Vcd_occupant_oa__nom is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_OCCUP_OA"
	cursor c3_occupation_oa (Vcd_occup_oa__type varchar) is
		select 1 
		from OA.CD_OCCUP_OA 
		where 
		TYPE = Vcd_occup_oa__type and Vcd_occup_oa__type is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.DSC_OA" doit exister à la création d'un enfant dans "OA.OCCUPATION_OA"
	if :new.DSC_OA__NUM_OA is not null and seq = 0 then 
		open c1_occupation_oa ( :new.DSC_OA__NUM_OA);
		fetch c1_occupation_oa into dummy;
		found := c1_occupation_oa%FOUND;
		close c1_occupation_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.DSC_OA". Impossible de modifier un enfant dans "OA.OCCUPATION_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_OCCUPANT_OA" doit exister à la création d'un enfant dans "OA.OCCUPATION_OA"
	if :new.CD_OCCUPANT_OA__NOM is not null and seq = 0 then 
		open c2_occupation_oa ( :new.CD_OCCUPANT_OA__NOM);
		fetch c2_occupation_oa into dummy;
		found := c2_occupation_oa%FOUND;
		close c2_occupation_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_OCCUPANT_OA". Impossible de modifier un enfant dans "OA.OCCUPATION_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_OCCUP_OA" doit exister à la création d'un enfant dans "OA.OCCUPATION_OA"
	if :new.CD_OCCUP_OA__TYPE is not null and seq = 0 then 
		open c3_occupation_oa ( :new.CD_OCCUP_OA__TYPE);
		fetch c3_occupation_oa into dummy;
		found := c3_occupation_oa%FOUND;
		close c3_occupation_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_OCCUP_OA". Impossible de modifier un enfant dans "OA.OCCUPATION_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUA_CDORIGINOA" after update
of ORIGINE
on OA.CD_ORIGIN_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.CD_ORIGIN_OA" dans les enfants "OA.HISTO_NOTE_OA"
	if ((updating('ORIGINE') and :old.ORIGINE != :new.ORIGINE)) then 
		update OA.HISTO_NOTE_OA
		set CD_ORIGIN_OA__ORIGINE = :new.ORIGINE  
		where CD_ORIGIN_OA__ORIGINE = :old.ORIGINE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_CDORIGINOA" after delete
on OA.CD_ORIGIN_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.HISTO_NOTE_OA"
	delete OA.HISTO_NOTE_OA
	where CD_ORIGIN_OA__ORIGINE = :old.ORIGINE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TIB_DSCOA" before insert
on OA.DSC_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_TYPE_OA"
	cursor c1_dsc_oa(Vcd_type_oa__type varchar) is
		select 1 
		from OA.CD_TYPE_OA 
		where 
		TYPE = Vcd_type_oa__type and Vcd_type_oa__type is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_ENTP_OA"
	cursor c2_dsc_oa(Vcd_entp_oa__entreprise varchar) is
		select 1 
		from OA.CD_ENTP_OA 
		where 
		ENTREPRISE = Vcd_entp_oa__entreprise and Vcd_entp_oa__entreprise is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_CHARGE_OA"
	cursor c3_dsc_oa(Vcd_charge_oa__surcharge varchar) is
		select 1 
		from OA.CD_CHARGE_OA 
		where 
		SURCHARGE = Vcd_charge_oa__surcharge and Vcd_charge_oa__surcharge is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_MAT_OA"
	cursor c4_dsc_oa(Vcd_mat_oa__materiaux varchar) is
		select 1 
		from OA.CD_MAT_OA 
		where 
		MATERIAUX = Vcd_mat_oa__materiaux and Vcd_mat_oa__materiaux is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_BE_OA"
	cursor c5_dsc_oa(Vcd_be_oa__bureau varchar) is
		select 1 
		from OA.CD_BE_OA 
		where 
		BUREAU = Vcd_be_oa__bureau and Vcd_be_oa__bureau is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_GEST_OA"
	cursor c6_dsc_oa(Vcd_gest_oa__gestionnaire varchar) is
		select 1 
		from OA.CD_GEST_OA 
		where 
		GESTIONNAIRE = Vcd_gest_oa__gestionnaire and Vcd_gest_oa__gestionnaire is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_FOND_OA"
	cursor c7_dsc_oa(Vcd_fond_oa__type varchar) is
		select 1 
		from OA.CD_FOND_OA 
		where 
		TYPE = Vcd_fond_oa__type and Vcd_fond_oa__type is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_TABLIER_OA"
	cursor c8_dsc_oa(Vcd_tablier_oa__tablier varchar) is
		select 1 
		from OA.CD_TABLIER_OA 
		where 
		TABLIER = Vcd_tablier_oa__tablier and Vcd_tablier_oa__tablier is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_MO_OA"
	cursor c9_dsc_oa(Vcd_mo_oa__maitre_ouvr varchar) is
		select 1 
		from OA.CD_MO_OA 
		where 
		MAITRE_OUVR = Vcd_mo_oa__maitre_ouvr and Vcd_mo_oa__maitre_ouvr is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_QUALITE_OA"
	cursor c10_dsc_oa(Vcd_iqoa_oa__note_iqoa varchar,
	Vcd_qualite_oa__qualite varchar) is
		select 1 
		from OA.CD_QUALITE_OA 
		where 
		CD_IQOA_OA__NOTE_IQOA = Vcd_iqoa_oa__note_iqoa and Vcd_iqoa_oa__note_iqoa is not null and 
		QUALITE = Vcd_qualite_oa__qualite and Vcd_qualite_oa__qualite is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_FAM_OA"
	cursor c11_dsc_oa(Vcd_fam_oa__famille varchar) is
		select 1 
		from OA.CD_FAM_OA 
		where 
		FAMILLE = Vcd_fam_oa__famille and Vcd_fam_oa__famille is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_HIERARCHIE_OA"
	cursor c12_dsc_oa(Vcd_hierarchie_oa__hierarchie varchar) is
		select 1 
		from OA.CD_HIERARCHIE_OA 
		where 
		HIERARCHIE = Vcd_hierarchie_oa__hierarchie and Vcd_hierarchie_oa__hierarchie is not null;
begin

	
	--  Le parent "OA.CD_TYPE_OA" doit exister à la création d'un enfant dans "OA.DSC_OA"
	if :new.CD_TYPE_OA__TYPE is not null then 
		open c1_dsc_oa ( :new.CD_TYPE_OA__TYPE);
		fetch c1_dsc_oa into dummy;
		found := c1_dsc_oa%FOUND;
		close c1_dsc_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_TYPE_OA". Impossible de créer un enfant dans "OA.DSC_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_ENTP_OA" doit exister à la création d'un enfant dans "OA.DSC_OA"
	if :new.CD_ENTP_OA__ENTREPRISE is not null then 
		open c2_dsc_oa ( :new.CD_ENTP_OA__ENTREPRISE);
		fetch c2_dsc_oa into dummy;
		found := c2_dsc_oa%FOUND;
		close c2_dsc_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_ENTP_OA". Impossible de créer un enfant dans "OA.DSC_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_CHARGE_OA" doit exister à la création d'un enfant dans "OA.DSC_OA"
	if :new.CD_CHARGE_OA__SURCHARGE is not null then 
		open c3_dsc_oa ( :new.CD_CHARGE_OA__SURCHARGE);
		fetch c3_dsc_oa into dummy;
		found := c3_dsc_oa%FOUND;
		close c3_dsc_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_CHARGE_OA". Impossible de créer un enfant dans "OA.DSC_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_MAT_OA" doit exister à la création d'un enfant dans "OA.DSC_OA"
	if :new.CD_MAT_OA__MATERIAUX is not null then 
		open c4_dsc_oa ( :new.CD_MAT_OA__MATERIAUX);
		fetch c4_dsc_oa into dummy;
		found := c4_dsc_oa%FOUND;
		close c4_dsc_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_MAT_OA". Impossible de créer un enfant dans "OA.DSC_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_BE_OA" doit exister à la création d'un enfant dans "OA.DSC_OA"
	if :new.CD_BE_OA__BUREAU is not null then 
		open c5_dsc_oa ( :new.CD_BE_OA__BUREAU);
		fetch c5_dsc_oa into dummy;
		found := c5_dsc_oa%FOUND;
		close c5_dsc_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_BE_OA". Impossible de créer un enfant dans "OA.DSC_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_GEST_OA" doit exister à la création d'un enfant dans "OA.DSC_OA"
	if :new.CD_GEST_OA__GESTIONNAIRE is not null then 
		open c6_dsc_oa ( :new.CD_GEST_OA__GESTIONNAIRE);
		fetch c6_dsc_oa into dummy;
		found := c6_dsc_oa%FOUND;
		close c6_dsc_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_GEST_OA". Impossible de créer un enfant dans "OA.DSC_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_FOND_OA" doit exister à la création d'un enfant dans "OA.DSC_OA"
	if :new.CD_FOND_OA__TYPE is not null then 
		open c7_dsc_oa ( :new.CD_FOND_OA__TYPE);
		fetch c7_dsc_oa into dummy;
		found := c7_dsc_oa%FOUND;
		close c7_dsc_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_FOND_OA". Impossible de créer un enfant dans "OA.DSC_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_TABLIER_OA" doit exister à la création d'un enfant dans "OA.DSC_OA"
	if :new.CD_TABLIER_OA__TABLIER is not null then 
		open c8_dsc_oa ( :new.CD_TABLIER_OA__TABLIER);
		fetch c8_dsc_oa into dummy;
		found := c8_dsc_oa%FOUND;
		close c8_dsc_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_TABLIER_OA". Impossible de créer un enfant dans "OA.DSC_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_MO_OA" doit exister à la création d'un enfant dans "OA.DSC_OA"
	if :new.CD_MO_OA__MAITRE_OUVR is not null then 
		open c9_dsc_oa ( :new.CD_MO_OA__MAITRE_OUVR);
		fetch c9_dsc_oa into dummy;
		found := c9_dsc_oa%FOUND;
		close c9_dsc_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_MO_OA". Impossible de créer un enfant dans "OA.DSC_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_QUALITE_OA" doit exister à la création d'un enfant dans "OA.DSC_OA"
	if :new.CD_IQOA_OA__NOTE_IQOA is not null and 
	:new.CD_QUALITE_OA__QUALITE is not null then 
		open c10_dsc_oa ( :new.CD_IQOA_OA__NOTE_IQOA,
		:new.CD_QUALITE_OA__QUALITE);
		fetch c10_dsc_oa into dummy;
		found := c10_dsc_oa%FOUND;
		close c10_dsc_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_QUALITE_OA". Impossible de créer un enfant dans "OA.DSC_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_FAM_OA" doit exister à la création d'un enfant dans "OA.DSC_OA"
	if :new.CD_FAM_OA__FAMILLE is not null then 
		open c11_dsc_oa ( :new.CD_FAM_OA__FAMILLE);
		fetch c11_dsc_oa into dummy;
		found := c11_dsc_oa%FOUND;
		close c11_dsc_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_FAM_OA". Impossible de créer un enfant dans "OA.DSC_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_HIERARCHIE_OA" doit exister à la création d'un enfant dans "OA.DSC_OA"
	if :new.CD_HIERARCHIE_OA__HIERARCHIE is not null then 
		open c12_dsc_oa ( :new.CD_HIERARCHIE_OA__HIERARCHIE);
		fetch c12_dsc_oa into dummy;
		found := c12_dsc_oa%FOUND;
		close c12_dsc_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_HIERARCHIE_OA". Impossible de créer un enfant dans "OA.DSC_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_DSCOA" before update
on OA.DSC_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_TYPE_OA"
	cursor c1_dsc_oa (Vcd_type_oa__type varchar) is
		select 1 
		from OA.CD_TYPE_OA 
		where 
		TYPE = Vcd_type_oa__type and Vcd_type_oa__type is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_ENTP_OA"
	cursor c2_dsc_oa (Vcd_entp_oa__entreprise varchar) is
		select 1 
		from OA.CD_ENTP_OA 
		where 
		ENTREPRISE = Vcd_entp_oa__entreprise and Vcd_entp_oa__entreprise is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_CHARGE_OA"
	cursor c3_dsc_oa (Vcd_charge_oa__surcharge varchar) is
		select 1 
		from OA.CD_CHARGE_OA 
		where 
		SURCHARGE = Vcd_charge_oa__surcharge and Vcd_charge_oa__surcharge is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_MAT_OA"
	cursor c4_dsc_oa (Vcd_mat_oa__materiaux varchar) is
		select 1 
		from OA.CD_MAT_OA 
		where 
		MATERIAUX = Vcd_mat_oa__materiaux and Vcd_mat_oa__materiaux is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_BE_OA"
	cursor c5_dsc_oa (Vcd_be_oa__bureau varchar) is
		select 1 
		from OA.CD_BE_OA 
		where 
		BUREAU = Vcd_be_oa__bureau and Vcd_be_oa__bureau is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_GEST_OA"
	cursor c6_dsc_oa (Vcd_gest_oa__gestionnaire varchar) is
		select 1 
		from OA.CD_GEST_OA 
		where 
		GESTIONNAIRE = Vcd_gest_oa__gestionnaire and Vcd_gest_oa__gestionnaire is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_FOND_OA"
	cursor c7_dsc_oa (Vcd_fond_oa__type varchar) is
		select 1 
		from OA.CD_FOND_OA 
		where 
		TYPE = Vcd_fond_oa__type and Vcd_fond_oa__type is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_TABLIER_OA"
	cursor c8_dsc_oa (Vcd_tablier_oa__tablier varchar) is
		select 1 
		from OA.CD_TABLIER_OA 
		where 
		TABLIER = Vcd_tablier_oa__tablier and Vcd_tablier_oa__tablier is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_MO_OA"
	cursor c9_dsc_oa (Vcd_mo_oa__maitre_ouvr varchar) is
		select 1 
		from OA.CD_MO_OA 
		where 
		MAITRE_OUVR = Vcd_mo_oa__maitre_ouvr and Vcd_mo_oa__maitre_ouvr is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_QUALITE_OA"
	cursor c10_dsc_oa (Vcd_iqoa_oa__note_iqoa varchar,
	Vcd_qualite_oa__qualite varchar) is
		select 1 
		from OA.CD_QUALITE_OA 
		where 
		CD_IQOA_OA__NOTE_IQOA = Vcd_iqoa_oa__note_iqoa and Vcd_iqoa_oa__note_iqoa is not null and 
		QUALITE = Vcd_qualite_oa__qualite and Vcd_qualite_oa__qualite is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_FAM_OA"
	cursor c11_dsc_oa (Vcd_fam_oa__famille varchar) is
		select 1 
		from OA.CD_FAM_OA 
		where 
		FAMILLE = Vcd_fam_oa__famille and Vcd_fam_oa__famille is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_HIERARCHIE_OA"
	cursor c12_dsc_oa (Vcd_hierarchie_oa__hierarchie varchar) is
		select 1 
		from OA.CD_HIERARCHIE_OA 
		where 
		HIERARCHIE = Vcd_hierarchie_oa__hierarchie and Vcd_hierarchie_oa__hierarchie is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.CD_TYPE_OA" doit exister à la création d'un enfant dans "OA.DSC_OA"
	if :new.CD_TYPE_OA__TYPE is not null and seq = 0 then 
		open c1_dsc_oa ( :new.CD_TYPE_OA__TYPE);
		fetch c1_dsc_oa into dummy;
		found := c1_dsc_oa%FOUND;
		close c1_dsc_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_TYPE_OA". Impossible de modifier un enfant dans "OA.DSC_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_ENTP_OA" doit exister à la création d'un enfant dans "OA.DSC_OA"
	if :new.CD_ENTP_OA__ENTREPRISE is not null and seq = 0 then 
		open c2_dsc_oa ( :new.CD_ENTP_OA__ENTREPRISE);
		fetch c2_dsc_oa into dummy;
		found := c2_dsc_oa%FOUND;
		close c2_dsc_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_ENTP_OA". Impossible de modifier un enfant dans "OA.DSC_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_CHARGE_OA" doit exister à la création d'un enfant dans "OA.DSC_OA"
	if :new.CD_CHARGE_OA__SURCHARGE is not null and seq = 0 then 
		open c3_dsc_oa ( :new.CD_CHARGE_OA__SURCHARGE);
		fetch c3_dsc_oa into dummy;
		found := c3_dsc_oa%FOUND;
		close c3_dsc_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_CHARGE_OA". Impossible de modifier un enfant dans "OA.DSC_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_MAT_OA" doit exister à la création d'un enfant dans "OA.DSC_OA"
	if :new.CD_MAT_OA__MATERIAUX is not null and seq = 0 then 
		open c4_dsc_oa ( :new.CD_MAT_OA__MATERIAUX);
		fetch c4_dsc_oa into dummy;
		found := c4_dsc_oa%FOUND;
		close c4_dsc_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_MAT_OA". Impossible de modifier un enfant dans "OA.DSC_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_BE_OA" doit exister à la création d'un enfant dans "OA.DSC_OA"
	if :new.CD_BE_OA__BUREAU is not null and seq = 0 then 
		open c5_dsc_oa ( :new.CD_BE_OA__BUREAU);
		fetch c5_dsc_oa into dummy;
		found := c5_dsc_oa%FOUND;
		close c5_dsc_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_BE_OA". Impossible de modifier un enfant dans "OA.DSC_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_GEST_OA" doit exister à la création d'un enfant dans "OA.DSC_OA"
	if :new.CD_GEST_OA__GESTIONNAIRE is not null and seq = 0 then 
		open c6_dsc_oa ( :new.CD_GEST_OA__GESTIONNAIRE);
		fetch c6_dsc_oa into dummy;
		found := c6_dsc_oa%FOUND;
		close c6_dsc_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_GEST_OA". Impossible de modifier un enfant dans "OA.DSC_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_FOND_OA" doit exister à la création d'un enfant dans "OA.DSC_OA"
	if :new.CD_FOND_OA__TYPE is not null and seq = 0 then 
		open c7_dsc_oa ( :new.CD_FOND_OA__TYPE);
		fetch c7_dsc_oa into dummy;
		found := c7_dsc_oa%FOUND;
		close c7_dsc_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_FOND_OA". Impossible de modifier un enfant dans "OA.DSC_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_TABLIER_OA" doit exister à la création d'un enfant dans "OA.DSC_OA"
	if :new.CD_TABLIER_OA__TABLIER is not null and seq = 0 then 
		open c8_dsc_oa ( :new.CD_TABLIER_OA__TABLIER);
		fetch c8_dsc_oa into dummy;
		found := c8_dsc_oa%FOUND;
		close c8_dsc_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_TABLIER_OA". Impossible de modifier un enfant dans "OA.DSC_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_MO_OA" doit exister à la création d'un enfant dans "OA.DSC_OA"
	if :new.CD_MO_OA__MAITRE_OUVR is not null and seq = 0 then 
		open c9_dsc_oa ( :new.CD_MO_OA__MAITRE_OUVR);
		fetch c9_dsc_oa into dummy;
		found := c9_dsc_oa%FOUND;
		close c9_dsc_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_MO_OA". Impossible de modifier un enfant dans "OA.DSC_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_QUALITE_OA" doit exister à la création d'un enfant dans "OA.DSC_OA"
	if :new.CD_IQOA_OA__NOTE_IQOA is not null and seq = 0 and 
	:new.CD_QUALITE_OA__QUALITE is not null and seq = 0 then 
		open c10_dsc_oa ( :new.CD_IQOA_OA__NOTE_IQOA,
		:new.CD_QUALITE_OA__QUALITE);
		fetch c10_dsc_oa into dummy;
		found := c10_dsc_oa%FOUND;
		close c10_dsc_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_QUALITE_OA". Impossible de modifier un enfant dans "OA.DSC_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_FAM_OA" doit exister à la création d'un enfant dans "OA.DSC_OA"
	if :new.CD_FAM_OA__FAMILLE is not null and seq = 0 then 
		open c11_dsc_oa ( :new.CD_FAM_OA__FAMILLE);
		fetch c11_dsc_oa into dummy;
		found := c11_dsc_oa%FOUND;
		close c11_dsc_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_FAM_OA". Impossible de modifier un enfant dans "OA.DSC_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_HIERARCHIE_OA" doit exister à la création d'un enfant dans "OA.DSC_OA"
	if :new.CD_HIERARCHIE_OA__HIERARCHIE is not null and seq = 0 then 
		open c12_dsc_oa ( :new.CD_HIERARCHIE_OA__HIERARCHIE);
		fetch c12_dsc_oa into dummy;
		found := c12_dsc_oa%FOUND;
		close c12_dsc_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_HIERARCHIE_OA". Impossible de modifier un enfant dans "OA.DSC_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUA_DSCOA" after update
of NUM_OA
on OA.DSC_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.DSC_OA" dans les enfants "OA.TABLIER_OA"
	if ((updating('NUM_OA') and :old.NUM_OA != :new.NUM_OA)) then 
		update OA.TABLIER_OA
		set DSC_OA__NUM_OA = :new.NUM_OA  
		where DSC_OA__NUM_OA = :old.NUM_OA;
	end if;
	--  Modification du code du parent "OA.DSC_OA" dans les enfants "OA.TRAVAUX_OA"
	if ((updating('NUM_OA') and :old.NUM_OA != :new.NUM_OA)) then 
		update OA.TRAVAUX_OA
		set DSC_OA__NUM_OA = :new.NUM_OA  
		where DSC_OA__NUM_OA = :old.NUM_OA;
	end if;
	--  Modification du code du parent "OA.DSC_OA" dans les enfants "OA.HISTO_NOTE_OA"
	if ((updating('NUM_OA') and :old.NUM_OA != :new.NUM_OA)) then 
		update OA.HISTO_NOTE_OA
		set DSC_OA__NUM_OA = :new.NUM_OA  
		where DSC_OA__NUM_OA = :old.NUM_OA;
	end if;
	--  Modification du code du parent "OA.DSC_OA" dans les enfants "OA.PREVISION_OA"
	if ((updating('NUM_OA') and :old.NUM_OA != :new.NUM_OA)) then 
		update OA.PREVISION_OA
		set DSC_OA__NUM_OA = :new.NUM_OA  
		where DSC_OA__NUM_OA = :old.NUM_OA;
	end if;
	--  Modification du code du parent "OA.DSC_OA" dans les enfants "OA.INSP_OA"
	if ((updating('NUM_OA') and :old.NUM_OA != :new.NUM_OA)) then 
		update OA.INSP_OA
		set DSC_OA__NUM_OA = :new.NUM_OA  
		where DSC_OA__NUM_OA = :old.NUM_OA;
	end if;
	--  Modification du code du parent "OA.DSC_OA" dans les enfants "OA.EVT_OA"
	if ((updating('NUM_OA') and :old.NUM_OA != :new.NUM_OA)) then 
		update OA.EVT_OA
		set DSC_OA__NUM_OA = :new.NUM_OA  
		where DSC_OA__NUM_OA = :old.NUM_OA;
	end if;
	--  Modification du code du parent "OA.DSC_OA" dans les enfants "OA.VST_OA"
	if ((updating('NUM_OA') and :old.NUM_OA != :new.NUM_OA)) then 
		update OA.VST_OA
		set DSC_OA__NUM_OA = :new.NUM_OA  
		where DSC_OA__NUM_OA = :old.NUM_OA;
	end if;
	--  Modification du code du parent "OA.DSC_OA" dans les enfants "OA.DSC_TEMP_OA"
	if ((updating('NUM_OA') and :old.NUM_OA != :new.NUM_OA)) then 
		update OA.DSC_TEMP_OA
		set DSC_OA__NUM_OA = :new.NUM_OA  
		where DSC_OA__NUM_OA = :old.NUM_OA;
	end if;
	--  Modification du code du parent "OA.DSC_OA" dans les enfants "OA.OCCUPATION_OA"
	if ((updating('NUM_OA') and :old.NUM_OA != :new.NUM_OA)) then 
		update OA.OCCUPATION_OA
		set DSC_OA__NUM_OA = :new.NUM_OA  
		where DSC_OA__NUM_OA = :old.NUM_OA;
	end if;
	--  Modification du code du parent "OA.DSC_OA" dans les enfants "OA.APPUIS_OA"
	if ((updating('NUM_OA') and :old.NUM_OA != :new.NUM_OA)) then 
		update OA.APPUIS_OA
		set DSC_OA__NUM_OA = :new.NUM_OA  
		where DSC_OA__NUM_OA = :old.NUM_OA;
	end if;
	--  Modification du code du parent "OA.DSC_OA" dans les enfants "OA.DSC_CAMP_OA"
	if ((updating('NUM_OA') and :old.NUM_OA != :new.NUM_OA)) then 
		update OA.DSC_CAMP_OA
		set DSC_OA__NUM_OA = :new.NUM_OA  
		where DSC_OA__NUM_OA = :old.NUM_OA;
	end if;
	--  Modification du code du parent "OA.DSC_OA" dans les enfants "OA.DSC__ARCHIVE_3_OA"
	if ((updating('NUM_OA') and :old.NUM_OA != :new.NUM_OA)) then 
		update OA.DSC__ARCHIVE_3_OA
		set DSC_OA__NUM_OA = :new.NUM_OA  
		where DSC_OA__NUM_OA = :old.NUM_OA;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_DSCOA" after delete
on OA.DSC_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.TABLIER_OA"
	delete OA.TABLIER_OA
	where DSC_OA__NUM_OA = :old.NUM_OA;
	
	--  Suppression des enfants dans "OA.TRAVAUX_OA"
	delete OA.TRAVAUX_OA
	where DSC_OA__NUM_OA = :old.NUM_OA;
	
	--  Suppression des enfants dans "OA.HISTO_NOTE_OA"
	delete OA.HISTO_NOTE_OA
	where DSC_OA__NUM_OA = :old.NUM_OA;
	
	--  Suppression des enfants dans "OA.PREVISION_OA"
	delete OA.PREVISION_OA
	where DSC_OA__NUM_OA = :old.NUM_OA;
	
	--  Suppression des enfants dans "OA.INSP_OA"
	delete OA.INSP_OA
	where DSC_OA__NUM_OA = :old.NUM_OA;
	
	--  Suppression des enfants dans "OA.EVT_OA"
	delete OA.EVT_OA
	where DSC_OA__NUM_OA = :old.NUM_OA;
	
	--  Suppression des enfants dans "OA.VST_OA"
	delete OA.VST_OA
	where DSC_OA__NUM_OA = :old.NUM_OA;
	
	--  Suppression des enfants dans "OA.DSC_TEMP_OA"
	delete OA.DSC_TEMP_OA
	where DSC_OA__NUM_OA = :old.NUM_OA;
	
	--  Suppression des enfants dans "OA.OCCUPATION_OA"
	delete OA.OCCUPATION_OA
	where DSC_OA__NUM_OA = :old.NUM_OA;
	
	--  Suppression des enfants dans "OA.APPUIS_OA"
	delete OA.APPUIS_OA
	where DSC_OA__NUM_OA = :old.NUM_OA;
	
	--  Suppression des enfants dans "OA.DSC_CAMP_OA"
	delete OA.DSC_CAMP_OA
	where DSC_OA__NUM_OA = :old.NUM_OA;
	
	--  Suppression des enfants dans "OA.DSC__ARCHIVE_3_OA"
	delete OA.DSC__ARCHIVE_3_OA
	where DSC_OA__NUM_OA = :old.NUM_OA;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TIB_DSCTEMPOA" before insert
on OA.DSC_TEMP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_MO_OA"
	cursor c1_dsc_temp_oa(Vcd_mo_oa__maitre_ouvr varchar) is
		select 1 
		from OA.CD_MO_OA 
		where 
		MAITRE_OUVR = Vcd_mo_oa__maitre_ouvr and Vcd_mo_oa__maitre_ouvr is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_ENTP_OA"
	cursor c2_dsc_temp_oa(Vcd_entp_oa__entreprise varchar) is
		select 1 
		from OA.CD_ENTP_OA 
		where 
		ENTREPRISE = Vcd_entp_oa__entreprise and Vcd_entp_oa__entreprise is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_BE_OA"
	cursor c3_dsc_temp_oa(Vcd_be_oa__bureau varchar) is
		select 1 
		from OA.CD_BE_OA 
		where 
		BUREAU = Vcd_be_oa__bureau and Vcd_be_oa__bureau is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_MAT_OA"
	cursor c4_dsc_temp_oa(Vcd_mat_oa__materiaux varchar) is
		select 1 
		from OA.CD_MAT_OA 
		where 
		MATERIAUX = Vcd_mat_oa__materiaux and Vcd_mat_oa__materiaux is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_CHARGE_OA"
	cursor c5_dsc_temp_oa(Vcd_charge_oa__surcharge varchar) is
		select 1 
		from OA.CD_CHARGE_OA 
		where 
		SURCHARGE = Vcd_charge_oa__surcharge and Vcd_charge_oa__surcharge is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_GEST_OA"
	cursor c6_dsc_temp_oa(Vcd_gest_oa__gestionnaire varchar) is
		select 1 
		from OA.CD_GEST_OA 
		where 
		GESTIONNAIRE = Vcd_gest_oa__gestionnaire and Vcd_gest_oa__gestionnaire is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_FOND_OA"
	cursor c7_dsc_temp_oa(Vcd_fond_oa__type varchar) is
		select 1 
		from OA.CD_FOND_OA 
		where 
		TYPE = Vcd_fond_oa__type and Vcd_fond_oa__type is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_TABLIER_OA"
	cursor c8_dsc_temp_oa(Vcd_tablier_oa__tablier varchar) is
		select 1 
		from OA.CD_TABLIER_OA 
		where 
		TABLIER = Vcd_tablier_oa__tablier and Vcd_tablier_oa__tablier is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_FAM_OA"
	cursor c9_dsc_temp_oa(Vcd_fam_oa__famille varchar) is
		select 1 
		from OA.CD_FAM_OA 
		where 
		FAMILLE = Vcd_fam_oa__famille and Vcd_fam_oa__famille is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_TYPE_OA"
	cursor c10_dsc_temp_oa(Vcd_type_oa__type varchar) is
		select 1 
		from OA.CD_TYPE_OA 
		where 
		TYPE = Vcd_type_oa__type and Vcd_type_oa__type is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CAMP_OA"
	cursor c11_dsc_temp_oa(Vcamp_oa__id_camp varchar) is
		select 1 
		from OA.CAMP_OA 
		where 
		ID_CAMP = Vcamp_oa__id_camp and Vcamp_oa__id_camp is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.DSC_OA"
	cursor c12_dsc_temp_oa(Vdsc_oa__num_oa varchar) is
		select 1 
		from OA.DSC_OA 
		where 
		NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null;
begin

	
	--  Le parent "OA.CD_MO_OA" doit exister à la création d'un enfant dans "OA.DSC_TEMP_OA"
	if :new.CD_MO_OA__MAITRE_OUVR is not null then 
		open c1_dsc_temp_oa ( :new.CD_MO_OA__MAITRE_OUVR);
		fetch c1_dsc_temp_oa into dummy;
		found := c1_dsc_temp_oa%FOUND;
		close c1_dsc_temp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_MO_OA". Impossible de créer un enfant dans "OA.DSC_TEMP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_ENTP_OA" doit exister à la création d'un enfant dans "OA.DSC_TEMP_OA"
	if :new.CD_ENTP_OA__ENTREPRISE is not null then 
		open c2_dsc_temp_oa ( :new.CD_ENTP_OA__ENTREPRISE);
		fetch c2_dsc_temp_oa into dummy;
		found := c2_dsc_temp_oa%FOUND;
		close c2_dsc_temp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_ENTP_OA". Impossible de créer un enfant dans "OA.DSC_TEMP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_BE_OA" doit exister à la création d'un enfant dans "OA.DSC_TEMP_OA"
	if :new.CD_BE_OA__BUREAU is not null then 
		open c3_dsc_temp_oa ( :new.CD_BE_OA__BUREAU);
		fetch c3_dsc_temp_oa into dummy;
		found := c3_dsc_temp_oa%FOUND;
		close c3_dsc_temp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_BE_OA". Impossible de créer un enfant dans "OA.DSC_TEMP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_MAT_OA" doit exister à la création d'un enfant dans "OA.DSC_TEMP_OA"
	if :new.CD_MAT_OA__MATERIAUX is not null then 
		open c4_dsc_temp_oa ( :new.CD_MAT_OA__MATERIAUX);
		fetch c4_dsc_temp_oa into dummy;
		found := c4_dsc_temp_oa%FOUND;
		close c4_dsc_temp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_MAT_OA". Impossible de créer un enfant dans "OA.DSC_TEMP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_CHARGE_OA" doit exister à la création d'un enfant dans "OA.DSC_TEMP_OA"
	if :new.CD_CHARGE_OA__SURCHARGE is not null then 
		open c5_dsc_temp_oa ( :new.CD_CHARGE_OA__SURCHARGE);
		fetch c5_dsc_temp_oa into dummy;
		found := c5_dsc_temp_oa%FOUND;
		close c5_dsc_temp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_CHARGE_OA". Impossible de créer un enfant dans "OA.DSC_TEMP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_GEST_OA" doit exister à la création d'un enfant dans "OA.DSC_TEMP_OA"
	if :new.CD_GEST_OA__GESTIONNAIRE is not null then 
		open c6_dsc_temp_oa ( :new.CD_GEST_OA__GESTIONNAIRE);
		fetch c6_dsc_temp_oa into dummy;
		found := c6_dsc_temp_oa%FOUND;
		close c6_dsc_temp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_GEST_OA". Impossible de créer un enfant dans "OA.DSC_TEMP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_FOND_OA" doit exister à la création d'un enfant dans "OA.DSC_TEMP_OA"
	if :new.CD_FOND_OA__TYPE is not null then 
		open c7_dsc_temp_oa ( :new.CD_FOND_OA__TYPE);
		fetch c7_dsc_temp_oa into dummy;
		found := c7_dsc_temp_oa%FOUND;
		close c7_dsc_temp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_FOND_OA". Impossible de créer un enfant dans "OA.DSC_TEMP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_TABLIER_OA" doit exister à la création d'un enfant dans "OA.DSC_TEMP_OA"
	if :new.CD_TABLIER_OA__TABLIER is not null then 
		open c8_dsc_temp_oa ( :new.CD_TABLIER_OA__TABLIER);
		fetch c8_dsc_temp_oa into dummy;
		found := c8_dsc_temp_oa%FOUND;
		close c8_dsc_temp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_TABLIER_OA". Impossible de créer un enfant dans "OA.DSC_TEMP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_FAM_OA" doit exister à la création d'un enfant dans "OA.DSC_TEMP_OA"
	if :new.CD_FAM_OA__FAMILLE is not null then 
		open c9_dsc_temp_oa ( :new.CD_FAM_OA__FAMILLE);
		fetch c9_dsc_temp_oa into dummy;
		found := c9_dsc_temp_oa%FOUND;
		close c9_dsc_temp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_FAM_OA". Impossible de créer un enfant dans "OA.DSC_TEMP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_TYPE_OA" doit exister à la création d'un enfant dans "OA.DSC_TEMP_OA"
	if :new.CD_TYPE_OA__TYPE is not null then 
		open c10_dsc_temp_oa ( :new.CD_TYPE_OA__TYPE);
		fetch c10_dsc_temp_oa into dummy;
		found := c10_dsc_temp_oa%FOUND;
		close c10_dsc_temp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_TYPE_OA". Impossible de créer un enfant dans "OA.DSC_TEMP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CAMP_OA" doit exister à la création d'un enfant dans "OA.DSC_TEMP_OA"
	if :new.CAMP_OA__ID_CAMP is not null then 
		open c11_dsc_temp_oa ( :new.CAMP_OA__ID_CAMP);
		fetch c11_dsc_temp_oa into dummy;
		found := c11_dsc_temp_oa%FOUND;
		close c11_dsc_temp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CAMP_OA". Impossible de créer un enfant dans "OA.DSC_TEMP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.DSC_OA" doit exister à la création d'un enfant dans "OA.DSC_TEMP_OA"
	if :new.DSC_OA__NUM_OA is not null then 
		open c12_dsc_temp_oa ( :new.DSC_OA__NUM_OA);
		fetch c12_dsc_temp_oa into dummy;
		found := c12_dsc_temp_oa%FOUND;
		close c12_dsc_temp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.DSC_OA". Impossible de créer un enfant dans "OA.DSC_TEMP_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_DSCTEMPOA" before update
on OA.DSC_TEMP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_MO_OA"
	cursor c1_dsc_temp_oa (Vcd_mo_oa__maitre_ouvr varchar) is
		select 1 
		from OA.CD_MO_OA 
		where 
		MAITRE_OUVR = Vcd_mo_oa__maitre_ouvr and Vcd_mo_oa__maitre_ouvr is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_ENTP_OA"
	cursor c2_dsc_temp_oa (Vcd_entp_oa__entreprise varchar) is
		select 1 
		from OA.CD_ENTP_OA 
		where 
		ENTREPRISE = Vcd_entp_oa__entreprise and Vcd_entp_oa__entreprise is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_BE_OA"
	cursor c3_dsc_temp_oa (Vcd_be_oa__bureau varchar) is
		select 1 
		from OA.CD_BE_OA 
		where 
		BUREAU = Vcd_be_oa__bureau and Vcd_be_oa__bureau is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_MAT_OA"
	cursor c4_dsc_temp_oa (Vcd_mat_oa__materiaux varchar) is
		select 1 
		from OA.CD_MAT_OA 
		where 
		MATERIAUX = Vcd_mat_oa__materiaux and Vcd_mat_oa__materiaux is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_CHARGE_OA"
	cursor c5_dsc_temp_oa (Vcd_charge_oa__surcharge varchar) is
		select 1 
		from OA.CD_CHARGE_OA 
		where 
		SURCHARGE = Vcd_charge_oa__surcharge and Vcd_charge_oa__surcharge is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_GEST_OA"
	cursor c6_dsc_temp_oa (Vcd_gest_oa__gestionnaire varchar) is
		select 1 
		from OA.CD_GEST_OA 
		where 
		GESTIONNAIRE = Vcd_gest_oa__gestionnaire and Vcd_gest_oa__gestionnaire is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_FOND_OA"
	cursor c7_dsc_temp_oa (Vcd_fond_oa__type varchar) is
		select 1 
		from OA.CD_FOND_OA 
		where 
		TYPE = Vcd_fond_oa__type and Vcd_fond_oa__type is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_TABLIER_OA"
	cursor c8_dsc_temp_oa (Vcd_tablier_oa__tablier varchar) is
		select 1 
		from OA.CD_TABLIER_OA 
		where 
		TABLIER = Vcd_tablier_oa__tablier and Vcd_tablier_oa__tablier is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_FAM_OA"
	cursor c9_dsc_temp_oa (Vcd_fam_oa__famille varchar) is
		select 1 
		from OA.CD_FAM_OA 
		where 
		FAMILLE = Vcd_fam_oa__famille and Vcd_fam_oa__famille is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_TYPE_OA"
	cursor c10_dsc_temp_oa (Vcd_type_oa__type varchar) is
		select 1 
		from OA.CD_TYPE_OA 
		where 
		TYPE = Vcd_type_oa__type and Vcd_type_oa__type is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CAMP_OA"
	cursor c11_dsc_temp_oa (Vcamp_oa__id_camp varchar) is
		select 1 
		from OA.CAMP_OA 
		where 
		ID_CAMP = Vcamp_oa__id_camp and Vcamp_oa__id_camp is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.DSC_OA"
	cursor c12_dsc_temp_oa (Vdsc_oa__num_oa varchar) is
		select 1 
		from OA.DSC_OA 
		where 
		NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.CD_MO_OA" doit exister à la création d'un enfant dans "OA.DSC_TEMP_OA"
	if :new.CD_MO_OA__MAITRE_OUVR is not null and seq = 0 then 
		open c1_dsc_temp_oa ( :new.CD_MO_OA__MAITRE_OUVR);
		fetch c1_dsc_temp_oa into dummy;
		found := c1_dsc_temp_oa%FOUND;
		close c1_dsc_temp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_MO_OA". Impossible de modifier un enfant dans "OA.DSC_TEMP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_ENTP_OA" doit exister à la création d'un enfant dans "OA.DSC_TEMP_OA"
	if :new.CD_ENTP_OA__ENTREPRISE is not null and seq = 0 then 
		open c2_dsc_temp_oa ( :new.CD_ENTP_OA__ENTREPRISE);
		fetch c2_dsc_temp_oa into dummy;
		found := c2_dsc_temp_oa%FOUND;
		close c2_dsc_temp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_ENTP_OA". Impossible de modifier un enfant dans "OA.DSC_TEMP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_BE_OA" doit exister à la création d'un enfant dans "OA.DSC_TEMP_OA"
	if :new.CD_BE_OA__BUREAU is not null and seq = 0 then 
		open c3_dsc_temp_oa ( :new.CD_BE_OA__BUREAU);
		fetch c3_dsc_temp_oa into dummy;
		found := c3_dsc_temp_oa%FOUND;
		close c3_dsc_temp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_BE_OA". Impossible de modifier un enfant dans "OA.DSC_TEMP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_MAT_OA" doit exister à la création d'un enfant dans "OA.DSC_TEMP_OA"
	if :new.CD_MAT_OA__MATERIAUX is not null and seq = 0 then 
		open c4_dsc_temp_oa ( :new.CD_MAT_OA__MATERIAUX);
		fetch c4_dsc_temp_oa into dummy;
		found := c4_dsc_temp_oa%FOUND;
		close c4_dsc_temp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_MAT_OA". Impossible de modifier un enfant dans "OA.DSC_TEMP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_CHARGE_OA" doit exister à la création d'un enfant dans "OA.DSC_TEMP_OA"
	if :new.CD_CHARGE_OA__SURCHARGE is not null and seq = 0 then 
		open c5_dsc_temp_oa ( :new.CD_CHARGE_OA__SURCHARGE);
		fetch c5_dsc_temp_oa into dummy;
		found := c5_dsc_temp_oa%FOUND;
		close c5_dsc_temp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_CHARGE_OA". Impossible de modifier un enfant dans "OA.DSC_TEMP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_GEST_OA" doit exister à la création d'un enfant dans "OA.DSC_TEMP_OA"
	if :new.CD_GEST_OA__GESTIONNAIRE is not null and seq = 0 then 
		open c6_dsc_temp_oa ( :new.CD_GEST_OA__GESTIONNAIRE);
		fetch c6_dsc_temp_oa into dummy;
		found := c6_dsc_temp_oa%FOUND;
		close c6_dsc_temp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_GEST_OA". Impossible de modifier un enfant dans "OA.DSC_TEMP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_FOND_OA" doit exister à la création d'un enfant dans "OA.DSC_TEMP_OA"
	if :new.CD_FOND_OA__TYPE is not null and seq = 0 then 
		open c7_dsc_temp_oa ( :new.CD_FOND_OA__TYPE);
		fetch c7_dsc_temp_oa into dummy;
		found := c7_dsc_temp_oa%FOUND;
		close c7_dsc_temp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_FOND_OA". Impossible de modifier un enfant dans "OA.DSC_TEMP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_TABLIER_OA" doit exister à la création d'un enfant dans "OA.DSC_TEMP_OA"
	if :new.CD_TABLIER_OA__TABLIER is not null and seq = 0 then 
		open c8_dsc_temp_oa ( :new.CD_TABLIER_OA__TABLIER);
		fetch c8_dsc_temp_oa into dummy;
		found := c8_dsc_temp_oa%FOUND;
		close c8_dsc_temp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_TABLIER_OA". Impossible de modifier un enfant dans "OA.DSC_TEMP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_FAM_OA" doit exister à la création d'un enfant dans "OA.DSC_TEMP_OA"
	if :new.CD_FAM_OA__FAMILLE is not null and seq = 0 then 
		open c9_dsc_temp_oa ( :new.CD_FAM_OA__FAMILLE);
		fetch c9_dsc_temp_oa into dummy;
		found := c9_dsc_temp_oa%FOUND;
		close c9_dsc_temp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_FAM_OA". Impossible de modifier un enfant dans "OA.DSC_TEMP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_TYPE_OA" doit exister à la création d'un enfant dans "OA.DSC_TEMP_OA"
	if :new.CD_TYPE_OA__TYPE is not null and seq = 0 then 
		open c10_dsc_temp_oa ( :new.CD_TYPE_OA__TYPE);
		fetch c10_dsc_temp_oa into dummy;
		found := c10_dsc_temp_oa%FOUND;
		close c10_dsc_temp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_TYPE_OA". Impossible de modifier un enfant dans "OA.DSC_TEMP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CAMP_OA" doit exister à la création d'un enfant dans "OA.DSC_TEMP_OA"
	if :new.CAMP_OA__ID_CAMP is not null and seq = 0 then 
		open c11_dsc_temp_oa ( :new.CAMP_OA__ID_CAMP);
		fetch c11_dsc_temp_oa into dummy;
		found := c11_dsc_temp_oa%FOUND;
		close c11_dsc_temp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CAMP_OA". Impossible de modifier un enfant dans "OA.DSC_TEMP_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.DSC_OA" doit exister à la création d'un enfant dans "OA.DSC_TEMP_OA"
	if :new.DSC_OA__NUM_OA is not null and seq = 0 then 
		open c12_dsc_temp_oa ( :new.DSC_OA__NUM_OA);
		fetch c12_dsc_temp_oa into dummy;
		found := c12_dsc_temp_oa%FOUND;
		close c12_dsc_temp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.DSC_OA". Impossible de modifier un enfant dans "OA.DSC_TEMP_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUA_DSCTEMPOA" after update
of CAMP_OA__ID_CAMP,NUM_OA
on OA.DSC_TEMP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.DSC_TEMP_OA" dans les enfants "OA.INSP_TMP_OA"
	if ((updating('CAMP_OA__ID_CAMP') and :old.CAMP_OA__ID_CAMP != :new.CAMP_OA__ID_CAMP) or 
	(updating('NUM_OA') and :old.NUM_OA != :new.NUM_OA)) then 
		update OA.INSP_TMP_OA
		set CAMP_OA__ID_CAMP = :new.CAMP_OA__ID_CAMP,
		DSC_TEMP_OA__NUM_OA = :new.NUM_OA  
		where CAMP_OA__ID_CAMP = :old.CAMP_OA__ID_CAMP and 
		DSC_TEMP_OA__NUM_OA = :old.NUM_OA;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_DSCTEMPOA" after delete
on OA.DSC_TEMP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.INSP_TMP_OA"
	delete OA.INSP_TMP_OA
	where CAMP_OA__ID_CAMP = :old.CAMP_OA__ID_CAMP and 
	DSC_TEMP_OA__NUM_OA = :old.NUM_OA;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TIB_PRTOA" before insert
on OA.PRT_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.GRP_OA"
	cursor c1_prt_oa(Vgrp_oa__id_grp number) is
		select 1 
		from OA.GRP_OA 
		where 
		ID_GRP = Vgrp_oa__id_grp and Vgrp_oa__id_grp is not null;
begin

	
	--  Le parent "OA.GRP_OA" doit exister à la création d'un enfant dans "OA.PRT_OA"
	if :new.GRP_OA__ID_GRP is not null then 
		open c1_prt_oa ( :new.GRP_OA__ID_GRP);
		fetch c1_prt_oa into dummy;
		found := c1_prt_oa%FOUND;
		close c1_prt_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.GRP_OA". Impossible de créer un enfant dans "OA.PRT_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_PRTOA" before update
on OA.PRT_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.GRP_OA"
	cursor c1_prt_oa (Vgrp_oa__id_grp number) is
		select 1 
		from OA.GRP_OA 
		where 
		ID_GRP = Vgrp_oa__id_grp and Vgrp_oa__id_grp is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.GRP_OA" doit exister à la création d'un enfant dans "OA.PRT_OA"
	if :new.GRP_OA__ID_GRP is not null and seq = 0 then 
		open c1_prt_oa ( :new.GRP_OA__ID_GRP);
		fetch c1_prt_oa into dummy;
		found := c1_prt_oa%FOUND;
		close c1_prt_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.GRP_OA". Impossible de modifier un enfant dans "OA.PRT_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUA_PRTOA" after update
of GRP_OA__ID_GRP,ID_PRT
on OA.PRT_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.PRT_OA" dans les enfants "OA.SPRT_OA"
	if ((updating('GRP_OA__ID_GRP') and :old.GRP_OA__ID_GRP != :new.GRP_OA__ID_GRP) or 
	(updating('ID_PRT') and :old.ID_PRT != :new.ID_PRT)) then 
		update OA.SPRT_OA
		set GRP_OA__ID_GRP = :new.GRP_OA__ID_GRP,
		PRT_OA__ID_PRT = :new.ID_PRT  
		where GRP_OA__ID_GRP = :old.GRP_OA__ID_GRP and 
		PRT_OA__ID_PRT = :old.ID_PRT;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_PRTOA" after delete
on OA.PRT_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.SPRT_OA"
	delete OA.SPRT_OA
	where GRP_OA__ID_GRP = :old.GRP_OA__ID_GRP and 
	PRT_OA__ID_PRT = :old.ID_PRT;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TIB_PHOTOINSPOA" before insert
on OA.PHOTO_INSP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.INSP_OA"
	cursor c1_photo_insp_oa(Vdsc_oa__num_oa varchar,
	Vcamp_oa__id_camp varchar) is
		select 1 
		from OA.INSP_OA 
		where 
		DSC_OA__NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null and 
		CAMP_OA__ID_CAMP = Vcamp_oa__id_camp and Vcamp_oa__id_camp is not null;
begin

	
	--  Le parent "OA.INSP_OA" doit exister à la création d'un enfant dans "OA.PHOTO_INSP_OA"
	if :new.DSC_OA__NUM_OA is not null and 
	:new.CAMP_OA__ID_CAMP is not null then 
		open c1_photo_insp_oa ( :new.DSC_OA__NUM_OA,
		:new.CAMP_OA__ID_CAMP);
		fetch c1_photo_insp_oa into dummy;
		found := c1_photo_insp_oa%FOUND;
		close c1_photo_insp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.INSP_OA". Impossible de créer un enfant dans "OA.PHOTO_INSP_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_PHOTOINSPOA" before update
on OA.PHOTO_INSP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.INSP_OA"
	cursor c1_photo_insp_oa (Vdsc_oa__num_oa varchar,
	Vcamp_oa__id_camp varchar) is
		select 1 
		from OA.INSP_OA 
		where 
		DSC_OA__NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null and 
		CAMP_OA__ID_CAMP = Vcamp_oa__id_camp and Vcamp_oa__id_camp is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.INSP_OA" doit exister à la création d'un enfant dans "OA.PHOTO_INSP_OA"
	if :new.DSC_OA__NUM_OA is not null and seq = 0 and 
	:new.CAMP_OA__ID_CAMP is not null and seq = 0 then 
		open c1_photo_insp_oa ( :new.DSC_OA__NUM_OA,
		:new.CAMP_OA__ID_CAMP);
		fetch c1_photo_insp_oa into dummy;
		found := c1_photo_insp_oa%FOUND;
		close c1_photo_insp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.INSP_OA". Impossible de modifier un enfant dans "OA.PHOTO_INSP_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TIB_PHOTOINSPTMPOA" before insert
on OA.PHOTO_INSP_TMP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.INSP_TMP_OA"
	cursor c1_photo_insp_tmp_oa(Vcamp_oa__id_camp varchar,
	Vdsc_temp_oa__num_oa varchar) is
		select 1 
		from OA.INSP_TMP_OA 
		where 
		CAMP_OA__ID_CAMP = Vcamp_oa__id_camp and Vcamp_oa__id_camp is not null and 
		DSC_TEMP_OA__NUM_OA = Vdsc_temp_oa__num_oa and Vdsc_temp_oa__num_oa is not null;
begin

	
	--  Le parent "OA.INSP_TMP_OA" doit exister à la création d'un enfant dans "OA.PHOTO_INSP_TMP_OA"
	if :new.CAMP_OA__ID_CAMP is not null and 
	:new.DSC_TEMP_OA__NUM_OA is not null then 
		open c1_photo_insp_tmp_oa ( :new.CAMP_OA__ID_CAMP,
		:new.DSC_TEMP_OA__NUM_OA);
		fetch c1_photo_insp_tmp_oa into dummy;
		found := c1_photo_insp_tmp_oa%FOUND;
		close c1_photo_insp_tmp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.INSP_TMP_OA". Impossible de créer un enfant dans "OA.PHOTO_INSP_TMP_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_PHOTOINSPTMPOA" before update
on OA.PHOTO_INSP_TMP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.INSP_TMP_OA"
	cursor c1_photo_insp_tmp_oa (Vcamp_oa__id_camp varchar,
	Vdsc_temp_oa__num_oa varchar) is
		select 1 
		from OA.INSP_TMP_OA 
		where 
		CAMP_OA__ID_CAMP = Vcamp_oa__id_camp and Vcamp_oa__id_camp is not null and 
		DSC_TEMP_OA__NUM_OA = Vdsc_temp_oa__num_oa and Vdsc_temp_oa__num_oa is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.INSP_TMP_OA" doit exister à la création d'un enfant dans "OA.PHOTO_INSP_TMP_OA"
	if :new.CAMP_OA__ID_CAMP is not null and seq = 0 and 
	:new.DSC_TEMP_OA__NUM_OA is not null and seq = 0 then 
		open c1_photo_insp_tmp_oa ( :new.CAMP_OA__ID_CAMP,
		:new.DSC_TEMP_OA__NUM_OA);
		fetch c1_photo_insp_tmp_oa into dummy;
		found := c1_photo_insp_tmp_oa%FOUND;
		close c1_photo_insp_tmp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.INSP_TMP_OA". Impossible de modifier un enfant dans "OA.PHOTO_INSP_TMP_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TIB_PHOTOVSTOA" before insert
on OA.PHOTO_VST_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.VST_OA"
	cursor c1_photo_vst_oa(Vdsc_oa__num_oa varchar,
	Vcamp_oa__id_camp varchar) is
		select 1 
		from OA.VST_OA 
		where 
		DSC_OA__NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null and 
		CAMP_OA__ID_CAMP = Vcamp_oa__id_camp and Vcamp_oa__id_camp is not null;
begin

	
	--  Le parent "OA.VST_OA" doit exister à la création d'un enfant dans "OA.PHOTO_VST_OA"
	if :new.DSC_OA__NUM_OA is not null and 
	:new.CAMP_OA__ID_CAMP is not null then 
		open c1_photo_vst_oa ( :new.DSC_OA__NUM_OA,
		:new.CAMP_OA__ID_CAMP);
		fetch c1_photo_vst_oa into dummy;
		found := c1_photo_vst_oa%FOUND;
		close c1_photo_vst_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.VST_OA". Impossible de créer un enfant dans "OA.PHOTO_VST_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_PHOTOVSTOA" before update
on OA.PHOTO_VST_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.VST_OA"
	cursor c1_photo_vst_oa (Vdsc_oa__num_oa varchar,
	Vcamp_oa__id_camp varchar) is
		select 1 
		from OA.VST_OA 
		where 
		DSC_OA__NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null and 
		CAMP_OA__ID_CAMP = Vcamp_oa__id_camp and Vcamp_oa__id_camp is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.VST_OA" doit exister à la création d'un enfant dans "OA.PHOTO_VST_OA"
	if :new.DSC_OA__NUM_OA is not null and seq = 0 and 
	:new.CAMP_OA__ID_CAMP is not null and seq = 0 then 
		open c1_photo_vst_oa ( :new.DSC_OA__NUM_OA,
		:new.CAMP_OA__ID_CAMP);
		fetch c1_photo_vst_oa into dummy;
		found := c1_photo_vst_oa%FOUND;
		close c1_photo_vst_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.VST_OA". Impossible de modifier un enfant dans "OA.PHOTO_VST_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TIB_PHOTOELTINSPOA" before insert
on OA.PHOTO_ELT_INSP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.ELT_INSP_OA"
	cursor c1_photo_elt_insp_oa(Vgrp_oa__id_grp number,
	Vprt_oa__id_prt number,
	Vsprt_oa__id_sprt number,
	Vdsc_oa__num_oa varchar,
	Vcamp_oa__id_camp varchar,
	Velt_oa__id_elem number) is
		select 1 
		from OA.ELT_INSP_OA 
		where 
		GRP_OA__ID_GRP = Vgrp_oa__id_grp and Vgrp_oa__id_grp is not null and 
		PRT_OA__ID_PRT = Vprt_oa__id_prt and Vprt_oa__id_prt is not null and 
		SPRT_OA__ID_SPRT = Vsprt_oa__id_sprt and Vsprt_oa__id_sprt is not null and 
		DSC_OA__NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null and 
		CAMP_OA__ID_CAMP = Vcamp_oa__id_camp and Vcamp_oa__id_camp is not null and 
		ELT_OA__ID_ELEM = Velt_oa__id_elem and Velt_oa__id_elem is not null;
begin

	
	--  Le parent "OA.ELT_INSP_OA" doit exister à la création d'un enfant dans "OA.PHOTO_ELT_INSP_OA"
	if :new.GRP_OA__ID_GRP is not null and 
	:new.PRT_OA__ID_PRT is not null and 
	:new.SPRT_OA__ID_SPRT is not null and 
	:new.DSC_OA__NUM_OA is not null and 
	:new.CAMP_OA__ID_CAMP is not null and 
	:new.ELT_OA__ID_ELEM is not null then 
		open c1_photo_elt_insp_oa ( :new.GRP_OA__ID_GRP,
		:new.PRT_OA__ID_PRT,
		:new.SPRT_OA__ID_SPRT,
		:new.DSC_OA__NUM_OA,
		:new.CAMP_OA__ID_CAMP,
		:new.ELT_OA__ID_ELEM);
		fetch c1_photo_elt_insp_oa into dummy;
		found := c1_photo_elt_insp_oa%FOUND;
		close c1_photo_elt_insp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.ELT_INSP_OA". Impossible de créer un enfant dans "OA.PHOTO_ELT_INSP_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_PHOTOELTINSPOA" before update
on OA.PHOTO_ELT_INSP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.ELT_INSP_OA"
	cursor c1_photo_elt_insp_oa (Vgrp_oa__id_grp number,
	Vprt_oa__id_prt number,
	Vsprt_oa__id_sprt number,
	Vdsc_oa__num_oa varchar,
	Vcamp_oa__id_camp varchar,
	Velt_oa__id_elem number) is
		select 1 
		from OA.ELT_INSP_OA 
		where 
		GRP_OA__ID_GRP = Vgrp_oa__id_grp and Vgrp_oa__id_grp is not null and 
		PRT_OA__ID_PRT = Vprt_oa__id_prt and Vprt_oa__id_prt is not null and 
		SPRT_OA__ID_SPRT = Vsprt_oa__id_sprt and Vsprt_oa__id_sprt is not null and 
		DSC_OA__NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null and 
		CAMP_OA__ID_CAMP = Vcamp_oa__id_camp and Vcamp_oa__id_camp is not null and 
		ELT_OA__ID_ELEM = Velt_oa__id_elem and Velt_oa__id_elem is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.ELT_INSP_OA" doit exister à la création d'un enfant dans "OA.PHOTO_ELT_INSP_OA"
	if :new.GRP_OA__ID_GRP is not null and seq = 0 and 
	:new.PRT_OA__ID_PRT is not null and seq = 0 and 
	:new.SPRT_OA__ID_SPRT is not null and seq = 0 and 
	:new.DSC_OA__NUM_OA is not null and seq = 0 and 
	:new.CAMP_OA__ID_CAMP is not null and seq = 0 and 
	:new.ELT_OA__ID_ELEM is not null and seq = 0 then 
		open c1_photo_elt_insp_oa ( :new.GRP_OA__ID_GRP,
		:new.PRT_OA__ID_PRT,
		:new.SPRT_OA__ID_SPRT,
		:new.DSC_OA__NUM_OA,
		:new.CAMP_OA__ID_CAMP,
		:new.ELT_OA__ID_ELEM);
		fetch c1_photo_elt_insp_oa into dummy;
		found := c1_photo_elt_insp_oa%FOUND;
		close c1_photo_elt_insp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.ELT_INSP_OA". Impossible de modifier un enfant dans "OA.PHOTO_ELT_INSP_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TIB_PHOTOELTINSPTMPOA" before insert
on OA.PHOTO_ELT_INSP_TMP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.ELT_INSP_TMP_OA"
	cursor c1_photo_elt_insp_tmp_oa(Vgrp_oa__id_grp number,
	Vprt_oa__id_prt number,
	Vsprt_oa__id_sprt number,
	Vcamp_oa__id_camp varchar,
	Vdsc_temp_oa__num_oa varchar,
	Velt_oa__id_elem number) is
		select 1 
		from OA.ELT_INSP_TMP_OA 
		where 
		GRP_OA__ID_GRP = Vgrp_oa__id_grp and Vgrp_oa__id_grp is not null and 
		PRT_OA__ID_PRT = Vprt_oa__id_prt and Vprt_oa__id_prt is not null and 
		SPRT_OA__ID_SPRT = Vsprt_oa__id_sprt and Vsprt_oa__id_sprt is not null and 
		CAMP_OA__ID_CAMP = Vcamp_oa__id_camp and Vcamp_oa__id_camp is not null and 
		DSC_TEMP_OA__NUM_OA = Vdsc_temp_oa__num_oa and Vdsc_temp_oa__num_oa is not null and 
		ELT_OA__ID_ELEM = Velt_oa__id_elem and Velt_oa__id_elem is not null;
begin

	
	--  Le parent "OA.ELT_INSP_TMP_OA" doit exister à la création d'un enfant dans "OA.PHOTO_ELT_INSP_TMP_OA"
	if :new.GRP_OA__ID_GRP is not null and 
	:new.PRT_OA__ID_PRT is not null and 
	:new.SPRT_OA__ID_SPRT is not null and 
	:new.CAMP_OA__ID_CAMP is not null and 
	:new.DSC_TEMP_OA__NUM_OA is not null and 
	:new.ELT_OA__ID_ELEM is not null then 
		open c1_photo_elt_insp_tmp_oa ( :new.GRP_OA__ID_GRP,
		:new.PRT_OA__ID_PRT,
		:new.SPRT_OA__ID_SPRT,
		:new.CAMP_OA__ID_CAMP,
		:new.DSC_TEMP_OA__NUM_OA,
		:new.ELT_OA__ID_ELEM);
		fetch c1_photo_elt_insp_tmp_oa into dummy;
		found := c1_photo_elt_insp_tmp_oa%FOUND;
		close c1_photo_elt_insp_tmp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.ELT_INSP_TMP_OA". Impossible de créer un enfant dans "OA.PHOTO_ELT_INSP_TMP_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_PHOTOELTINSPTMPOA" before update
on OA.PHOTO_ELT_INSP_TMP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.ELT_INSP_TMP_OA"
	cursor c1_photo_elt_insp_tmp_oa (Vgrp_oa__id_grp number,
	Vprt_oa__id_prt number,
	Vsprt_oa__id_sprt number,
	Vcamp_oa__id_camp varchar,
	Vdsc_temp_oa__num_oa varchar,
	Velt_oa__id_elem number) is
		select 1 
		from OA.ELT_INSP_TMP_OA 
		where 
		GRP_OA__ID_GRP = Vgrp_oa__id_grp and Vgrp_oa__id_grp is not null and 
		PRT_OA__ID_PRT = Vprt_oa__id_prt and Vprt_oa__id_prt is not null and 
		SPRT_OA__ID_SPRT = Vsprt_oa__id_sprt and Vsprt_oa__id_sprt is not null and 
		CAMP_OA__ID_CAMP = Vcamp_oa__id_camp and Vcamp_oa__id_camp is not null and 
		DSC_TEMP_OA__NUM_OA = Vdsc_temp_oa__num_oa and Vdsc_temp_oa__num_oa is not null and 
		ELT_OA__ID_ELEM = Velt_oa__id_elem and Velt_oa__id_elem is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.ELT_INSP_TMP_OA" doit exister à la création d'un enfant dans "OA.PHOTO_ELT_INSP_TMP_OA"
	if :new.GRP_OA__ID_GRP is not null and seq = 0 and 
	:new.PRT_OA__ID_PRT is not null and seq = 0 and 
	:new.SPRT_OA__ID_SPRT is not null and seq = 0 and 
	:new.CAMP_OA__ID_CAMP is not null and seq = 0 and 
	:new.DSC_TEMP_OA__NUM_OA is not null and seq = 0 and 
	:new.ELT_OA__ID_ELEM is not null and seq = 0 then 
		open c1_photo_elt_insp_tmp_oa ( :new.GRP_OA__ID_GRP,
		:new.PRT_OA__ID_PRT,
		:new.SPRT_OA__ID_SPRT,
		:new.CAMP_OA__ID_CAMP,
		:new.DSC_TEMP_OA__NUM_OA,
		:new.ELT_OA__ID_ELEM);
		fetch c1_photo_elt_insp_tmp_oa into dummy;
		found := c1_photo_elt_insp_tmp_oa%FOUND;
		close c1_photo_elt_insp_tmp_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.ELT_INSP_TMP_OA". Impossible de modifier un enfant dans "OA.PHOTO_ELT_INSP_TMP_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TIB_PHOTOSPRTVSTOA" before insert
on OA.PHOTO_SPRT_VST_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.SPRT_VST_OA"
	cursor c1_photo_sprt_vst_oa(Vdsc_oa__num_oa varchar,
	Vcamp_oa__id_camp varchar,
	Vcd_chapitre_oa__id_chap number,
	Vcd_ligne_oa__id_ligne number) is
		select 1 
		from OA.SPRT_VST_OA 
		where 
		DSC_OA__NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null and 
		CAMP_OA__ID_CAMP = Vcamp_oa__id_camp and Vcamp_oa__id_camp is not null and 
		CD_CHAPITRE_OA__ID_CHAP = Vcd_chapitre_oa__id_chap and Vcd_chapitre_oa__id_chap is not null and 
		CD_LIGNE_OA__ID_LIGNE = Vcd_ligne_oa__id_ligne and Vcd_ligne_oa__id_ligne is not null;
begin

	
	--  Le parent "OA.SPRT_VST_OA" doit exister à la création d'un enfant dans "OA.PHOTO_SPRT_VST_OA"
	if :new.DSC_OA__NUM_OA is not null and 
	:new.CAMP_OA__ID_CAMP is not null and 
	:new.CD_CHAPITRE_OA__ID_CHAP is not null and 
	:new.CD_LIGNE_OA__ID_LIGNE is not null then 
		open c1_photo_sprt_vst_oa ( :new.DSC_OA__NUM_OA,
		:new.CAMP_OA__ID_CAMP,
		:new.CD_CHAPITRE_OA__ID_CHAP,
		:new.CD_LIGNE_OA__ID_LIGNE);
		fetch c1_photo_sprt_vst_oa into dummy;
		found := c1_photo_sprt_vst_oa%FOUND;
		close c1_photo_sprt_vst_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.SPRT_VST_OA". Impossible de créer un enfant dans "OA.PHOTO_SPRT_VST_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_PHOTOSPRTVSTOA" before update
on OA.PHOTO_SPRT_VST_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.SPRT_VST_OA"
	cursor c1_photo_sprt_vst_oa (Vdsc_oa__num_oa varchar,
	Vcamp_oa__id_camp varchar,
	Vcd_chapitre_oa__id_chap number,
	Vcd_ligne_oa__id_ligne number) is
		select 1 
		from OA.SPRT_VST_OA 
		where 
		DSC_OA__NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null and 
		CAMP_OA__ID_CAMP = Vcamp_oa__id_camp and Vcamp_oa__id_camp is not null and 
		CD_CHAPITRE_OA__ID_CHAP = Vcd_chapitre_oa__id_chap and Vcd_chapitre_oa__id_chap is not null and 
		CD_LIGNE_OA__ID_LIGNE = Vcd_ligne_oa__id_ligne and Vcd_ligne_oa__id_ligne is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.SPRT_VST_OA" doit exister à la création d'un enfant dans "OA.PHOTO_SPRT_VST_OA"
	if :new.DSC_OA__NUM_OA is not null and seq = 0 and 
	:new.CAMP_OA__ID_CAMP is not null and seq = 0 and 
	:new.CD_CHAPITRE_OA__ID_CHAP is not null and seq = 0 and 
	:new.CD_LIGNE_OA__ID_LIGNE is not null and seq = 0 then 
		open c1_photo_sprt_vst_oa ( :new.DSC_OA__NUM_OA,
		:new.CAMP_OA__ID_CAMP,
		:new.CD_CHAPITRE_OA__ID_CHAP,
		:new.CD_LIGNE_OA__ID_LIGNE);
		fetch c1_photo_sprt_vst_oa into dummy;
		found := c1_photo_sprt_vst_oa%FOUND;
		close c1_photo_sprt_vst_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.SPRT_VST_OA". Impossible de modifier un enfant dans "OA.PHOTO_SPRT_VST_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUA_CDPRESTAOA" after update
of PRESTATAIRE
on OA.CD_PRESTA_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.CD_PRESTA_OA" dans les enfants "OA.CAMP_OA"
	if ((updating('PRESTATAIRE') and :old.PRESTATAIRE != :new.PRESTATAIRE)) then 
		update OA.CAMP_OA
		set CD_PRESTA_OA__PRESTATAIRE = :new.PRESTATAIRE  
		where CD_PRESTA_OA__PRESTATAIRE = :old.PRESTATAIRE;
	end if;
	--  Modification du code du parent "OA.CD_PRESTA_OA" dans les enfants "OA.INSPECTEUR_OA"
	if ((updating('PRESTATAIRE') and :old.PRESTATAIRE != :new.PRESTATAIRE)) then 
		update OA.INSPECTEUR_OA
		set CD_PRESTA_OA__PRESTATAIRE = :new.PRESTATAIRE  
		where CD_PRESTA_OA__PRESTATAIRE = :old.PRESTATAIRE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_CDPRESTAOA" after delete
on OA.CD_PRESTA_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.CAMP_OA"
	delete OA.CAMP_OA
	where CD_PRESTA_OA__PRESTATAIRE = :old.PRESTATAIRE;
	
	--  Suppression des enfants dans "OA.INSPECTEUR_OA"
	delete OA.INSPECTEUR_OA
	where CD_PRESTA_OA__PRESTATAIRE = :old.PRESTATAIRE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TIB_PREVISIONOA" before insert
on OA.PREVISION_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_CONTRAINTE_OA"
	cursor c1_prevision_oa(Vcd_contrainte_oa__type varchar) is
		select 1 
		from OA.CD_CONTRAINTE_OA 
		where 
		TYPE = Vcd_contrainte_oa__type and Vcd_contrainte_oa__type is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.DSC_OA"
	cursor c2_prevision_oa(Vdsc_oa__num_oa varchar) is
		select 1 
		from OA.DSC_OA 
		where 
		NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.BPU_OA"
	cursor c3_prevision_oa(Vbpu_oa__id_bpu number) is
		select 1 
		from OA.BPU_OA 
		where 
		ID_BPU = Vbpu_oa__id_bpu and Vbpu_oa__id_bpu is not null;
begin

	
	--  Le parent "OA.CD_CONTRAINTE_OA" doit exister à la création d'un enfant dans "OA.PREVISION_OA"
	if :new.CD_CONTRAINTE_OA__TYPE is not null then 
		open c1_prevision_oa ( :new.CD_CONTRAINTE_OA__TYPE);
		fetch c1_prevision_oa into dummy;
		found := c1_prevision_oa%FOUND;
		close c1_prevision_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_CONTRAINTE_OA". Impossible de créer un enfant dans "OA.PREVISION_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.DSC_OA" doit exister à la création d'un enfant dans "OA.PREVISION_OA"
	if :new.DSC_OA__NUM_OA is not null then 
		open c2_prevision_oa ( :new.DSC_OA__NUM_OA);
		fetch c2_prevision_oa into dummy;
		found := c2_prevision_oa%FOUND;
		close c2_prevision_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.DSC_OA". Impossible de créer un enfant dans "OA.PREVISION_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.BPU_OA" doit exister à la création d'un enfant dans "OA.PREVISION_OA"
	if :new.BPU_OA__ID_BPU is not null then 
		open c3_prevision_oa ( :new.BPU_OA__ID_BPU);
		fetch c3_prevision_oa into dummy;
		found := c3_prevision_oa%FOUND;
		close c3_prevision_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.BPU_OA". Impossible de créer un enfant dans "OA.PREVISION_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_PREVISIONOA" before update
on OA.PREVISION_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_CONTRAINTE_OA"
	cursor c1_prevision_oa (Vcd_contrainte_oa__type varchar) is
		select 1 
		from OA.CD_CONTRAINTE_OA 
		where 
		TYPE = Vcd_contrainte_oa__type and Vcd_contrainte_oa__type is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.DSC_OA"
	cursor c2_prevision_oa (Vdsc_oa__num_oa varchar) is
		select 1 
		from OA.DSC_OA 
		where 
		NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.BPU_OA"
	cursor c3_prevision_oa (Vbpu_oa__id_bpu number) is
		select 1 
		from OA.BPU_OA 
		where 
		ID_BPU = Vbpu_oa__id_bpu and Vbpu_oa__id_bpu is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.CD_CONTRAINTE_OA" doit exister à la création d'un enfant dans "OA.PREVISION_OA"
	if :new.CD_CONTRAINTE_OA__TYPE is not null and seq = 0 then 
		open c1_prevision_oa ( :new.CD_CONTRAINTE_OA__TYPE);
		fetch c1_prevision_oa into dummy;
		found := c1_prevision_oa%FOUND;
		close c1_prevision_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_CONTRAINTE_OA". Impossible de modifier un enfant dans "OA.PREVISION_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.DSC_OA" doit exister à la création d'un enfant dans "OA.PREVISION_OA"
	if :new.DSC_OA__NUM_OA is not null and seq = 0 then 
		open c2_prevision_oa ( :new.DSC_OA__NUM_OA);
		fetch c2_prevision_oa into dummy;
		found := c2_prevision_oa%FOUND;
		close c2_prevision_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.DSC_OA". Impossible de modifier un enfant dans "OA.PREVISION_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.BPU_OA" doit exister à la création d'un enfant dans "OA.PREVISION_OA"
	if :new.BPU_OA__ID_BPU is not null and seq = 0 then 
		open c3_prevision_oa ( :new.BPU_OA__ID_BPU);
		fetch c3_prevision_oa into dummy;
		found := c3_prevision_oa%FOUND;
		close c3_prevision_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.BPU_OA". Impossible de modifier un enfant dans "OA.PREVISION_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TIB_ENTETEOA" before insert
on OA.ENTETE_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_ENTETE_OA"
	cursor c1_entete_oa(Vcd_entete_oa__id_entete number) is
		select 1 
		from OA.CD_ENTETE_OA 
		where 
		ID_ENTETE = Vcd_entete_oa__id_entete and Vcd_entete_oa__id_entete is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.VST_OA"
	cursor c2_entete_oa(Vdsc_oa__num_oa varchar,
	Vcamp_oa__id_camp varchar) is
		select 1 
		from OA.VST_OA 
		where 
		DSC_OA__NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null and 
		CAMP_OA__ID_CAMP = Vcamp_oa__id_camp and Vcamp_oa__id_camp is not null;
begin

	
	--  Le parent "OA.CD_ENTETE_OA" doit exister à la création d'un enfant dans "OA.ENTETE_OA"
	if :new.CD_ENTETE_OA__ID_ENTETE is not null then 
		open c1_entete_oa ( :new.CD_ENTETE_OA__ID_ENTETE);
		fetch c1_entete_oa into dummy;
		found := c1_entete_oa%FOUND;
		close c1_entete_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_ENTETE_OA". Impossible de créer un enfant dans "OA.ENTETE_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.VST_OA" doit exister à la création d'un enfant dans "OA.ENTETE_OA"
	if :new.DSC_OA__NUM_OA is not null and 
	:new.CAMP_OA__ID_CAMP is not null then 
		open c2_entete_oa ( :new.DSC_OA__NUM_OA,
		:new.CAMP_OA__ID_CAMP);
		fetch c2_entete_oa into dummy;
		found := c2_entete_oa%FOUND;
		close c2_entete_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.VST_OA". Impossible de créer un enfant dans "OA.ENTETE_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_ENTETEOA" before update
on OA.ENTETE_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_ENTETE_OA"
	cursor c1_entete_oa (Vcd_entete_oa__id_entete number) is
		select 1 
		from OA.CD_ENTETE_OA 
		where 
		ID_ENTETE = Vcd_entete_oa__id_entete and Vcd_entete_oa__id_entete is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.VST_OA"
	cursor c2_entete_oa (Vdsc_oa__num_oa varchar,
	Vcamp_oa__id_camp varchar) is
		select 1 
		from OA.VST_OA 
		where 
		DSC_OA__NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null and 
		CAMP_OA__ID_CAMP = Vcamp_oa__id_camp and Vcamp_oa__id_camp is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.CD_ENTETE_OA" doit exister à la création d'un enfant dans "OA.ENTETE_OA"
	if :new.CD_ENTETE_OA__ID_ENTETE is not null and seq = 0 then 
		open c1_entete_oa ( :new.CD_ENTETE_OA__ID_ENTETE);
		fetch c1_entete_oa into dummy;
		found := c1_entete_oa%FOUND;
		close c1_entete_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_ENTETE_OA". Impossible de modifier un enfant dans "OA.ENTETE_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.VST_OA" doit exister à la création d'un enfant dans "OA.ENTETE_OA"
	if :new.DSC_OA__NUM_OA is not null and seq = 0 and 
	:new.CAMP_OA__ID_CAMP is not null and seq = 0 then 
		open c2_entete_oa ( :new.DSC_OA__NUM_OA,
		:new.CAMP_OA__ID_CAMP);
		fetch c2_entete_oa into dummy;
		found := c2_entete_oa%FOUND;
		close c2_entete_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.VST_OA". Impossible de modifier un enfant dans "OA.ENTETE_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TIB_SPRTOA" before insert
on OA.SPRT_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.PRT_OA"
	cursor c1_sprt_oa(Vgrp_oa__id_grp number,
	Vprt_oa__id_prt number) is
		select 1 
		from OA.PRT_OA 
		where 
		GRP_OA__ID_GRP = Vgrp_oa__id_grp and Vgrp_oa__id_grp is not null and 
		ID_PRT = Vprt_oa__id_prt and Vprt_oa__id_prt is not null;
begin

	
	--  Le parent "OA.PRT_OA" doit exister à la création d'un enfant dans "OA.SPRT_OA"
	if :new.GRP_OA__ID_GRP is not null and 
	:new.PRT_OA__ID_PRT is not null then 
		open c1_sprt_oa ( :new.GRP_OA__ID_GRP,
		:new.PRT_OA__ID_PRT);
		fetch c1_sprt_oa into dummy;
		found := c1_sprt_oa%FOUND;
		close c1_sprt_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.PRT_OA". Impossible de créer un enfant dans "OA.SPRT_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_SPRTOA" before update
on OA.SPRT_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.PRT_OA"
	cursor c1_sprt_oa (Vgrp_oa__id_grp number,
	Vprt_oa__id_prt number) is
		select 1 
		from OA.PRT_OA 
		where 
		GRP_OA__ID_GRP = Vgrp_oa__id_grp and Vgrp_oa__id_grp is not null and 
		ID_PRT = Vprt_oa__id_prt and Vprt_oa__id_prt is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.PRT_OA" doit exister à la création d'un enfant dans "OA.SPRT_OA"
	if :new.GRP_OA__ID_GRP is not null and seq = 0 and 
	:new.PRT_OA__ID_PRT is not null and seq = 0 then 
		open c1_sprt_oa ( :new.GRP_OA__ID_GRP,
		:new.PRT_OA__ID_PRT);
		fetch c1_sprt_oa into dummy;
		found := c1_sprt_oa%FOUND;
		close c1_sprt_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.PRT_OA". Impossible de modifier un enfant dans "OA.SPRT_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUA_SPRTOA" after update
of GRP_OA__ID_GRP,PRT_OA__ID_PRT,ID_SPRT
on OA.SPRT_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.SPRT_OA" dans les enfants "OA.ELT_OA"
	if ((updating('GRP_OA__ID_GRP') and :old.GRP_OA__ID_GRP != :new.GRP_OA__ID_GRP) or 
	(updating('PRT_OA__ID_PRT') and :old.PRT_OA__ID_PRT != :new.PRT_OA__ID_PRT) or 
	(updating('ID_SPRT') and :old.ID_SPRT != :new.ID_SPRT)) then 
		update OA.ELT_OA
		set GRP_OA__ID_GRP = :new.GRP_OA__ID_GRP,
		PRT_OA__ID_PRT = :new.PRT_OA__ID_PRT,
		SPRT_OA__ID_SPRT = :new.ID_SPRT  
		where GRP_OA__ID_GRP = :old.GRP_OA__ID_GRP and 
		PRT_OA__ID_PRT = :old.PRT_OA__ID_PRT and 
		SPRT_OA__ID_SPRT = :old.ID_SPRT;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_SPRTOA" after delete
on OA.SPRT_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.ELT_OA"
	delete OA.ELT_OA
	where GRP_OA__ID_GRP = :old.GRP_OA__ID_GRP and 
	PRT_OA__ID_PRT = :old.PRT_OA__ID_PRT and 
	SPRT_OA__ID_SPRT = :old.ID_SPRT;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TIB_TABLIEROA" before insert
on OA.TABLIER_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.DSC_OA"
	cursor c1_tablier_oa(Vdsc_oa__num_oa varchar) is
		select 1 
		from OA.DSC_OA 
		where 
		NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_CHAPE_OA"
	cursor c2_tablier_oa(Vcd_chape_oa__chape varchar) is
		select 1 
		from OA.CD_CHAPE_OA 
		where 
		CHAPE = Vcd_chape_oa__chape and Vcd_chape_oa__chape is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_TECH_OA"
	cursor c3_tablier_oa(Vcd_tech_oa__technique varchar) is
		select 1 
		from OA.CD_TECH_OA 
		where 
		TECHNIQUE = Vcd_tech_oa__technique and Vcd_tech_oa__technique is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_ENTP_OA"
	cursor c4_tablier_oa(Vcd_entp_oa__entreprise varchar) is
		select 1 
		from OA.CD_ENTP_OA 
		where 
		ENTREPRISE = Vcd_entp_oa__entreprise and Vcd_entp_oa__entreprise is not null;
begin

	
	--  Le parent "OA.DSC_OA" doit exister à la création d'un enfant dans "OA.TABLIER_OA"
	if :new.DSC_OA__NUM_OA is not null then 
		open c1_tablier_oa ( :new.DSC_OA__NUM_OA);
		fetch c1_tablier_oa into dummy;
		found := c1_tablier_oa%FOUND;
		close c1_tablier_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.DSC_OA". Impossible de créer un enfant dans "OA.TABLIER_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_CHAPE_OA" doit exister à la création d'un enfant dans "OA.TABLIER_OA"
	if :new.CD_CHAPE_OA__CHAPE is not null then 
		open c2_tablier_oa ( :new.CD_CHAPE_OA__CHAPE);
		fetch c2_tablier_oa into dummy;
		found := c2_tablier_oa%FOUND;
		close c2_tablier_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_CHAPE_OA". Impossible de créer un enfant dans "OA.TABLIER_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_TECH_OA" doit exister à la création d'un enfant dans "OA.TABLIER_OA"
	if :new.CD_TECH_OA__TECHNIQUE is not null then 
		open c3_tablier_oa ( :new.CD_TECH_OA__TECHNIQUE);
		fetch c3_tablier_oa into dummy;
		found := c3_tablier_oa%FOUND;
		close c3_tablier_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_TECH_OA". Impossible de créer un enfant dans "OA.TABLIER_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_ENTP_OA" doit exister à la création d'un enfant dans "OA.TABLIER_OA"
	if :new.CD_ENTP_OA__ENTREPRISE is not null then 
		open c4_tablier_oa ( :new.CD_ENTP_OA__ENTREPRISE);
		fetch c4_tablier_oa into dummy;
		found := c4_tablier_oa%FOUND;
		close c4_tablier_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_ENTP_OA". Impossible de créer un enfant dans "OA.TABLIER_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_TABLIEROA" before update
on OA.TABLIER_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.DSC_OA"
	cursor c1_tablier_oa (Vdsc_oa__num_oa varchar) is
		select 1 
		from OA.DSC_OA 
		where 
		NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_CHAPE_OA"
	cursor c2_tablier_oa (Vcd_chape_oa__chape varchar) is
		select 1 
		from OA.CD_CHAPE_OA 
		where 
		CHAPE = Vcd_chape_oa__chape and Vcd_chape_oa__chape is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_TECH_OA"
	cursor c3_tablier_oa (Vcd_tech_oa__technique varchar) is
		select 1 
		from OA.CD_TECH_OA 
		where 
		TECHNIQUE = Vcd_tech_oa__technique and Vcd_tech_oa__technique is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_ENTP_OA"
	cursor c4_tablier_oa (Vcd_entp_oa__entreprise varchar) is
		select 1 
		from OA.CD_ENTP_OA 
		where 
		ENTREPRISE = Vcd_entp_oa__entreprise and Vcd_entp_oa__entreprise is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.DSC_OA" doit exister à la création d'un enfant dans "OA.TABLIER_OA"
	if :new.DSC_OA__NUM_OA is not null and seq = 0 then 
		open c1_tablier_oa ( :new.DSC_OA__NUM_OA);
		fetch c1_tablier_oa into dummy;
		found := c1_tablier_oa%FOUND;
		close c1_tablier_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.DSC_OA". Impossible de modifier un enfant dans "OA.TABLIER_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_CHAPE_OA" doit exister à la création d'un enfant dans "OA.TABLIER_OA"
	if :new.CD_CHAPE_OA__CHAPE is not null and seq = 0 then 
		open c2_tablier_oa ( :new.CD_CHAPE_OA__CHAPE);
		fetch c2_tablier_oa into dummy;
		found := c2_tablier_oa%FOUND;
		close c2_tablier_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_CHAPE_OA". Impossible de modifier un enfant dans "OA.TABLIER_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_TECH_OA" doit exister à la création d'un enfant dans "OA.TABLIER_OA"
	if :new.CD_TECH_OA__TECHNIQUE is not null and seq = 0 then 
		open c3_tablier_oa ( :new.CD_TECH_OA__TECHNIQUE);
		fetch c3_tablier_oa into dummy;
		found := c3_tablier_oa%FOUND;
		close c3_tablier_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_TECH_OA". Impossible de modifier un enfant dans "OA.TABLIER_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_ENTP_OA" doit exister à la création d'un enfant dans "OA.TABLIER_OA"
	if :new.CD_ENTP_OA__ENTREPRISE is not null and seq = 0 then 
		open c4_tablier_oa ( :new.CD_ENTP_OA__ENTREPRISE);
		fetch c4_tablier_oa into dummy;
		found := c4_tablier_oa%FOUND;
		close c4_tablier_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_ENTP_OA". Impossible de modifier un enfant dans "OA.TABLIER_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUA_TABLIEROA" after update
of DSC_OA__NUM_OA,NUM_TAB
on OA.TABLIER_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.TABLIER_OA" dans les enfants "OA.JOINT_OA"
	if ((updating('DSC_OA__NUM_OA') and :old.DSC_OA__NUM_OA != :new.DSC_OA__NUM_OA) or 
	(updating('NUM_TAB') and :old.NUM_TAB != :new.NUM_TAB)) then 
		update OA.JOINT_OA
		set DSC_OA__NUM_OA = :new.DSC_OA__NUM_OA,
		TABLIER_OA__NUM_TAB = :new.NUM_TAB  
		where DSC_OA__NUM_OA = :old.DSC_OA__NUM_OA and 
		TABLIER_OA__NUM_TAB = :old.NUM_TAB;
	end if;
	--  Modification du code du parent "OA.TABLIER_OA" dans les enfants "OA.EQUIPEMENT_OA"
	if ((updating('DSC_OA__NUM_OA') and :old.DSC_OA__NUM_OA != :new.DSC_OA__NUM_OA) or 
	(updating('NUM_TAB') and :old.NUM_TAB != :new.NUM_TAB)) then 
		update OA.EQUIPEMENT_OA
		set DSC_OA__NUM_OA = :new.DSC_OA__NUM_OA,
		TABLIER_OA__NUM_TAB = :new.NUM_TAB  
		where DSC_OA__NUM_OA = :old.DSC_OA__NUM_OA and 
		TABLIER_OA__NUM_TAB = :old.NUM_TAB;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_TABLIEROA" after delete
on OA.TABLIER_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.JOINT_OA"
	delete OA.JOINT_OA
	where DSC_OA__NUM_OA = :old.DSC_OA__NUM_OA and 
	TABLIER_OA__NUM_TAB = :old.NUM_TAB;
	
	--  Suppression des enfants dans "OA.EQUIPEMENT_OA"
	delete OA.EQUIPEMENT_OA
	where DSC_OA__NUM_OA = :old.DSC_OA__NUM_OA and 
	TABLIER_OA__NUM_TAB = :old.NUM_TAB;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TIB_TRAVAUXOA" before insert
on OA.TRAVAUX_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.DSC_OA"
	cursor c1_travaux_oa(Vdsc_oa__num_oa varchar) is
		select 1 
		from OA.DSC_OA 
		where 
		NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.NATURE_TRAV_OA"
	cursor c2_travaux_oa(Vcd_travaux_oa__code varchar,
	Vnature_trav_oa__nature varchar) is
		select 1 
		from OA.NATURE_TRAV_OA 
		where 
		CD_TRAVAUX_OA__CODE = Vcd_travaux_oa__code and Vcd_travaux_oa__code is not null and 
		NATURE = Vnature_trav_oa__nature and Vnature_trav_oa__nature is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CD_ENTP_OA"
	cursor c3_travaux_oa(Vcd_entp_oa__entreprise varchar) is
		select 1 
		from OA.CD_ENTP_OA 
		where 
		ENTREPRISE = Vcd_entp_oa__entreprise and Vcd_entp_oa__entreprise is not null;
begin

	
	--  Le parent "OA.DSC_OA" doit exister à la création d'un enfant dans "OA.TRAVAUX_OA"
	if :new.DSC_OA__NUM_OA is not null then 
		open c1_travaux_oa ( :new.DSC_OA__NUM_OA);
		fetch c1_travaux_oa into dummy;
		found := c1_travaux_oa%FOUND;
		close c1_travaux_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.DSC_OA". Impossible de créer un enfant dans "OA.TRAVAUX_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.NATURE_TRAV_OA" doit exister à la création d'un enfant dans "OA.TRAVAUX_OA"
	if :new.CD_TRAVAUX_OA__CODE is not null and 
	:new.NATURE_TRAV_OA__NATURE is not null then 
		open c2_travaux_oa ( :new.CD_TRAVAUX_OA__CODE,
		:new.NATURE_TRAV_OA__NATURE);
		fetch c2_travaux_oa into dummy;
		found := c2_travaux_oa%FOUND;
		close c2_travaux_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.NATURE_TRAV_OA". Impossible de créer un enfant dans "OA.TRAVAUX_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_ENTP_OA" doit exister à la création d'un enfant dans "OA.TRAVAUX_OA"
	if :new.CD_ENTP_OA__ENTREPRISE is not null then 
		open c3_travaux_oa ( :new.CD_ENTP_OA__ENTREPRISE);
		fetch c3_travaux_oa into dummy;
		found := c3_travaux_oa%FOUND;
		close c3_travaux_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_ENTP_OA". Impossible de créer un enfant dans "OA.TRAVAUX_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_TRAVAUXOA" before update
on OA.TRAVAUX_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.DSC_OA"
	cursor c1_travaux_oa (Vdsc_oa__num_oa varchar) is
		select 1 
		from OA.DSC_OA 
		where 
		NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.NATURE_TRAV_OA"
	cursor c2_travaux_oa (Vcd_travaux_oa__code varchar,
	Vnature_trav_oa__nature varchar) is
		select 1 
		from OA.NATURE_TRAV_OA 
		where 
		CD_TRAVAUX_OA__CODE = Vcd_travaux_oa__code and Vcd_travaux_oa__code is not null and 
		NATURE = Vnature_trav_oa__nature and Vnature_trav_oa__nature is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CD_ENTP_OA"
	cursor c3_travaux_oa (Vcd_entp_oa__entreprise varchar) is
		select 1 
		from OA.CD_ENTP_OA 
		where 
		ENTREPRISE = Vcd_entp_oa__entreprise and Vcd_entp_oa__entreprise is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.DSC_OA" doit exister à la création d'un enfant dans "OA.TRAVAUX_OA"
	if :new.DSC_OA__NUM_OA is not null and seq = 0 then 
		open c1_travaux_oa ( :new.DSC_OA__NUM_OA);
		fetch c1_travaux_oa into dummy;
		found := c1_travaux_oa%FOUND;
		close c1_travaux_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.DSC_OA". Impossible de modifier un enfant dans "OA.TRAVAUX_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.NATURE_TRAV_OA" doit exister à la création d'un enfant dans "OA.TRAVAUX_OA"
	if :new.CD_TRAVAUX_OA__CODE is not null and seq = 0 and 
	:new.NATURE_TRAV_OA__NATURE is not null and seq = 0 then 
		open c2_travaux_oa ( :new.CD_TRAVAUX_OA__CODE,
		:new.NATURE_TRAV_OA__NATURE);
		fetch c2_travaux_oa into dummy;
		found := c2_travaux_oa%FOUND;
		close c2_travaux_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.NATURE_TRAV_OA". Impossible de modifier un enfant dans "OA.TRAVAUX_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CD_ENTP_OA" doit exister à la création d'un enfant dans "OA.TRAVAUX_OA"
	if :new.CD_ENTP_OA__ENTREPRISE is not null and seq = 0 then 
		open c3_travaux_oa ( :new.CD_ENTP_OA__ENTREPRISE);
		fetch c3_travaux_oa into dummy;
		found := c3_travaux_oa%FOUND;
		close c3_travaux_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CD_ENTP_OA". Impossible de modifier un enfant dans "OA.TRAVAUX_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUA_CDCOMPOSANTOA" after update
of TYPE_COMP
on OA.CD_COMPOSANT_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.CD_COMPOSANT_OA" dans les enfants "OA.CD_ENTETE_OA"
	if ((updating('TYPE_COMP') and :old.TYPE_COMP != :new.TYPE_COMP)) then 
		update OA.CD_ENTETE_OA
		set CD_COMPOSANT_OA__TYPE_COMP = :new.TYPE_COMP  
		where CD_COMPOSANT_OA__TYPE_COMP = :old.TYPE_COMP;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_CDCOMPOSANTOA" after delete
on OA.CD_COMPOSANT_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.CD_ENTETE_OA"
	delete OA.CD_ENTETE_OA
	where CD_COMPOSANT_OA__TYPE_COMP = :old.TYPE_COMP;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TUA_CDCHARGEOA" after update
of SURCHARGE
on OA.CD_CHARGE_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.CD_CHARGE_OA" dans les enfants "OA.DSC_OA"
	if ((updating('SURCHARGE') and :old.SURCHARGE != :new.SURCHARGE)) then 
		update OA.DSC_OA
		set CD_CHARGE_OA__SURCHARGE = :new.SURCHARGE  
		where CD_CHARGE_OA__SURCHARGE = :old.SURCHARGE;
	end if;
	--  Modification du code du parent "OA.CD_CHARGE_OA" dans les enfants "OA.DSC_TEMP_OA"
	if ((updating('SURCHARGE') and :old.SURCHARGE != :new.SURCHARGE)) then 
		update OA.DSC_TEMP_OA
		set CD_CHARGE_OA__SURCHARGE = :new.SURCHARGE  
		where CD_CHARGE_OA__SURCHARGE = :old.SURCHARGE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_CDCHARGEOA" after delete
on OA.CD_CHARGE_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.DSC_OA"
	delete OA.DSC_OA
	where CD_CHARGE_OA__SURCHARGE = :old.SURCHARGE;
	
	--  Suppression des enfants dans "OA.DSC_TEMP_OA"
	delete OA.DSC_TEMP_OA
	where CD_CHARGE_OA__SURCHARGE = :old.SURCHARGE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TUA_CDEVTOA" after update
of TYPE
on OA.CD_EVT_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.CD_EVT_OA" dans les enfants "OA.EVT_OA"
	if ((updating('TYPE') and :old.TYPE != :new.TYPE)) then 
		update OA.EVT_OA
		set CD_EVT_OA__TYPE = :new.TYPE  
		where CD_EVT_OA__TYPE = :old.TYPE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_CDEVTOA" after delete
on OA.CD_EVT_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.EVT_OA"
	delete OA.EVT_OA
	where CD_EVT_OA__TYPE = :old.TYPE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TUA_CDTYPEOA" after update
of TYPE
on OA.CD_TYPE_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.CD_TYPE_OA" dans les enfants "OA.DSC_OA"
	if ((updating('TYPE') and :old.TYPE != :new.TYPE)) then 
		update OA.DSC_OA
		set CD_TYPE_OA__TYPE = :new.TYPE  
		where CD_TYPE_OA__TYPE = :old.TYPE;
	end if;
	--  Modification du code du parent "OA.CD_TYPE_OA" dans les enfants "OA.DSC_TEMP_OA"
	if ((updating('TYPE') and :old.TYPE != :new.TYPE)) then 
		update OA.DSC_TEMP_OA
		set CD_TYPE_OA__TYPE = :new.TYPE  
		where CD_TYPE_OA__TYPE = :old.TYPE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_CDTYPEOA" after delete
on OA.CD_TYPE_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.DSC_OA"
	delete OA.DSC_OA
	where CD_TYPE_OA__TYPE = :old.TYPE;
	
	--  Suppression des enfants dans "OA.DSC_TEMP_OA"
	delete OA.DSC_TEMP_OA
	where CD_TYPE_OA__TYPE = :old.TYPE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TUA_CDOCCUPOA" after update
of TYPE
on OA.CD_OCCUP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.CD_OCCUP_OA" dans les enfants "OA.OCCUPATION_OA"
	if ((updating('TYPE') and :old.TYPE != :new.TYPE)) then 
		update OA.OCCUPATION_OA
		set CD_OCCUP_OA__TYPE = :new.TYPE  
		where CD_OCCUP_OA__TYPE = :old.TYPE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_CDOCCUPOA" after delete
on OA.CD_OCCUP_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.OCCUPATION_OA"
	delete OA.OCCUPATION_OA
	where CD_OCCUP_OA__TYPE = :old.TYPE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TUA_CDTYPEPVOA" after update
of CODE
on OA.CD_TYPE_PV_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.CD_TYPE_PV_OA" dans les enfants "OA.CAMP_OA"
	if ((updating('CODE') and :old.CODE != :new.CODE)) then 
		update OA.CAMP_OA
		set CD_TYPE_PV_OA__CODE = :new.CODE  
		where CD_TYPE_PV_OA__CODE = :old.CODE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_CDTYPEPVOA" after delete
on OA.CD_TYPE_PV_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.CAMP_OA"
	delete OA.CAMP_OA
	where CD_TYPE_PV_OA__CODE = :old.CODE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TUA_CDTRAVAUXOA" after update
of CODE
on OA.CD_TRAVAUX_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.CD_TRAVAUX_OA" dans les enfants "OA.BPU_OA"
	if ((updating('CODE') and :old.CODE != :new.CODE)) then 
		update OA.BPU_OA
		set CD_TRAVAUX_OA__CODE = :new.CODE  
		where CD_TRAVAUX_OA__CODE = :old.CODE;
	end if;
	--  Modification du code du parent "OA.CD_TRAVAUX_OA" dans les enfants "OA.NATURE_TRAV_OA"
	if ((updating('CODE') and :old.CODE != :new.CODE)) then 
		update OA.NATURE_TRAV_OA
		set CD_TRAVAUX_OA__CODE = :new.CODE  
		where CD_TRAVAUX_OA__CODE = :old.CODE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_CDTRAVAUXOA" after delete
on OA.CD_TRAVAUX_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.BPU_OA"
	delete OA.BPU_OA
	where CD_TRAVAUX_OA__CODE = :old.CODE;
	
	--  Suppression des enfants dans "OA.NATURE_TRAV_OA"
	delete OA.NATURE_TRAV_OA
	where CD_TRAVAUX_OA__CODE = :old.CODE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TUA_CDAPPAPPUIOA" after update
of APPUI
on OA.CD_APP_APPUI_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.CD_APP_APPUI_OA" dans les enfants "OA.APPUIS_OA"
	if ((updating('APPUI') and :old.APPUI != :new.APPUI)) then 
		update OA.APPUIS_OA
		set CD_APP_APPUI_OA__APPUI = :new.APPUI  
		where CD_APP_APPUI_OA__APPUI = :old.APPUI;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_CDAPPAPPUIOA" after delete
on OA.CD_APP_APPUI_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.APPUIS_OA"
	delete OA.APPUIS_OA
	where CD_APP_APPUI_OA__APPUI = :old.APPUI;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TUA_CDAPPUIOA" after update
of APP
on OA.CD_APPUI_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.CD_APPUI_OA" dans les enfants "OA.APPUIS_OA"
	if ((updating('APP') and :old.APP != :new.APP)) then 
		update OA.APPUIS_OA
		set CD_APPUI_OA__APP = :new.APP  
		where CD_APPUI_OA__APP = :old.APP;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_CDAPPUIOA" after delete
on OA.CD_APPUI_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.APPUIS_OA"
	delete OA.APPUIS_OA
	where CD_APPUI_OA__APP = :old.APP;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TUA_CDCHAPEOA" after update
of CHAPE
on OA.CD_CHAPE_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.CD_CHAPE_OA" dans les enfants "OA.TABLIER_OA"
	if ((updating('CHAPE') and :old.CHAPE != :new.CHAPE)) then 
		update OA.TABLIER_OA
		set CD_CHAPE_OA__CHAPE = :new.CHAPE  
		where CD_CHAPE_OA__CHAPE = :old.CHAPE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_CDCHAPEOA" after delete
on OA.CD_CHAPE_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.TABLIER_OA"
	delete OA.TABLIER_OA
	where CD_CHAPE_OA__CHAPE = :old.CHAPE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TUA_CDDPROA" after update
of DPR
on OA.CD_DPR_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.CD_DPR_OA" dans les enfants "OA.EQUIPEMENT_OA"
	if ((updating('DPR') and :old.DPR != :new.DPR)) then 
		update OA.EQUIPEMENT_OA
		set CD_DPR_OA__DPR = :new.DPR  
		where CD_DPR_OA__DPR = :old.DPR;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_CDDPROA" after delete
on OA.CD_DPR_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.EQUIPEMENT_OA"
	delete OA.EQUIPEMENT_OA
	where CD_DPR_OA__DPR = :old.DPR;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TUA_CDDOCOA" after update
of CODE
on OA.CD_DOC_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.CD_DOC_OA" dans les enfants "OA.DOC_OA"
	if ((updating('CODE') and :old.CODE != :new.CODE)) then 
		update OA.DOC_OA
		set CD_DOC__CODE = :new.CODE  
		where CD_DOC__CODE = :old.CODE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_CDDOCOA" after delete
on OA.CD_DOC_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.DOC_OA"
	delete OA.DOC_OA
	where CD_DOC__CODE = :old.CODE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TUA_CDFONDOA" after update
of TYPE
on OA.CD_FOND_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.CD_FOND_OA" dans les enfants "OA.DSC_OA"
	if ((updating('TYPE') and :old.TYPE != :new.TYPE)) then 
		update OA.DSC_OA
		set CD_FOND_OA__TYPE = :new.TYPE  
		where CD_FOND_OA__TYPE = :old.TYPE;
	end if;
	--  Modification du code du parent "OA.CD_FOND_OA" dans les enfants "OA.DSC_TEMP_OA"
	if ((updating('TYPE') and :old.TYPE != :new.TYPE)) then 
		update OA.DSC_TEMP_OA
		set CD_FOND_OA__TYPE = :new.TYPE  
		where CD_FOND_OA__TYPE = :old.TYPE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_CDFONDOA" after delete
on OA.CD_FOND_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.DSC_OA"
	delete OA.DSC_OA
	where CD_FOND_OA__TYPE = :old.TYPE;
	
	--  Suppression des enfants dans "OA.DSC_TEMP_OA"
	delete OA.DSC_TEMP_OA
	where CD_FOND_OA__TYPE = :old.TYPE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TUA_CDGCOA" after update
of GARDE_CORPS
on OA.CD_GC_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.CD_GC_OA" dans les enfants "OA.EQUIPEMENT_OA"
	if ((updating('GARDE_CORPS') and :old.GARDE_CORPS != :new.GARDE_CORPS)) then 
		update OA.EQUIPEMENT_OA
		set CD_GC_OA__GARDE_CORPS = :new.GARDE_CORPS  
		where CD_GC_OA__GARDE_CORPS = :old.GARDE_CORPS;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_CDGCOA" after delete
on OA.CD_GC_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.EQUIPEMENT_OA"
	delete OA.EQUIPEMENT_OA
	where CD_GC_OA__GARDE_CORPS = :old.GARDE_CORPS;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TUA_CDJOINTOA" after update
of TYPE
on OA.CD_JOINT_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.CD_JOINT_OA" dans les enfants "OA.JOINT_OA"
	if ((updating('TYPE') and :old.TYPE != :new.TYPE)) then 
		update OA.JOINT_OA
		set CD_JOINT_OA__TYPE = :new.TYPE  
		where CD_JOINT_OA__TYPE = :old.TYPE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_CDJOINTOA" after delete
on OA.CD_JOINT_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.JOINT_OA"
	delete OA.JOINT_OA
	where CD_JOINT_OA__TYPE = :old.TYPE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TUA_CDTABLIEROA" after update
of TABLIER
on OA.CD_TABLIER_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.CD_TABLIER_OA" dans les enfants "OA.DSC_OA"
	if ((updating('TABLIER') and :old.TABLIER != :new.TABLIER)) then 
		update OA.DSC_OA
		set CD_TABLIER_OA__TABLIER = :new.TABLIER  
		where CD_TABLIER_OA__TABLIER = :old.TABLIER;
	end if;
	--  Modification du code du parent "OA.CD_TABLIER_OA" dans les enfants "OA.DSC_TEMP_OA"
	if ((updating('TABLIER') and :old.TABLIER != :new.TABLIER)) then 
		update OA.DSC_TEMP_OA
		set CD_TABLIER_OA__TABLIER = :new.TABLIER  
		where CD_TABLIER_OA__TABLIER = :old.TABLIER;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_CDTABLIEROA" after delete
on OA.CD_TABLIER_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.DSC_OA"
	delete OA.DSC_OA
	where CD_TABLIER_OA__TABLIER = :old.TABLIER;
	
	--  Suppression des enfants dans "OA.DSC_TEMP_OA"
	delete OA.DSC_TEMP_OA
	where CD_TABLIER_OA__TABLIER = :old.TABLIER;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TUA_CDUNITEOA" after update
of UNITE
on OA.CD_UNITE_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.CD_UNITE_OA" dans les enfants "OA.BPU_OA"
	if ((updating('UNITE') and :old.UNITE != :new.UNITE)) then 
		update OA.BPU_OA
		set CD_UNITE_OA__UNITE = :new.UNITE  
		where CD_UNITE_OA__UNITE = :old.UNITE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_CDUNITEOA" after delete
on OA.CD_UNITE_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.BPU_OA"
	delete OA.BPU_OA
	where CD_UNITE_OA__UNITE = :old.UNITE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TIB_VSTOA" before insert
on OA.VST_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.DSC_OA"
	cursor c1_vst_oa(Vdsc_oa__num_oa varchar) is
		select 1 
		from OA.DSC_OA 
		where 
		NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.CAMP_OA"
	cursor c2_vst_oa(Vcamp_oa__id_camp varchar) is
		select 1 
		from OA.CAMP_OA 
		where 
		ID_CAMP = Vcamp_oa__id_camp and Vcamp_oa__id_camp is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OA.INSPECTEUR_OA"
	cursor c3_vst_oa(Vinspecteur_oa__nom varchar) is
		select 1 
		from OA.INSPECTEUR_OA 
		where 
		NOM = Vinspecteur_oa__nom and Vinspecteur_oa__nom is not null;
begin

	
	--  Le parent "OA.DSC_OA" doit exister à la création d'un enfant dans "OA.VST_OA"
	if :new.DSC_OA__NUM_OA is not null then 
		open c1_vst_oa ( :new.DSC_OA__NUM_OA);
		fetch c1_vst_oa into dummy;
		found := c1_vst_oa%FOUND;
		close c1_vst_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.DSC_OA". Impossible de créer un enfant dans "OA.VST_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CAMP_OA" doit exister à la création d'un enfant dans "OA.VST_OA"
	if :new.CAMP_OA__ID_CAMP is not null then 
		open c2_vst_oa ( :new.CAMP_OA__ID_CAMP);
		fetch c2_vst_oa into dummy;
		found := c2_vst_oa%FOUND;
		close c2_vst_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CAMP_OA". Impossible de créer un enfant dans "OA.VST_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.INSPECTEUR_OA" doit exister à la création d'un enfant dans "OA.VST_OA"
	if :new.INSPECTEUR_OA__NOM is not null then 
		open c3_vst_oa ( :new.INSPECTEUR_OA__NOM);
		fetch c3_vst_oa into dummy;
		found := c3_vst_oa%FOUND;
		close c3_vst_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.INSPECTEUR_OA". Impossible de créer un enfant dans "OA.VST_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUB_VSTOA" before update
on OA.VST_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.DSC_OA"
	cursor c1_vst_oa (Vdsc_oa__num_oa varchar) is
		select 1 
		from OA.DSC_OA 
		where 
		NUM_OA = Vdsc_oa__num_oa and Vdsc_oa__num_oa is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.CAMP_OA"
	cursor c2_vst_oa (Vcamp_oa__id_camp varchar) is
		select 1 
		from OA.CAMP_OA 
		where 
		ID_CAMP = Vcamp_oa__id_camp and Vcamp_oa__id_camp is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OA.INSPECTEUR_OA"
	cursor c3_vst_oa (Vinspecteur_oa__nom varchar) is
		select 1 
		from OA.INSPECTEUR_OA 
		where 
		NOM = Vinspecteur_oa__nom and Vinspecteur_oa__nom is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OA.DSC_OA" doit exister à la création d'un enfant dans "OA.VST_OA"
	if :new.DSC_OA__NUM_OA is not null and seq = 0 then 
		open c1_vst_oa ( :new.DSC_OA__NUM_OA);
		fetch c1_vst_oa into dummy;
		found := c1_vst_oa%FOUND;
		close c1_vst_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.DSC_OA". Impossible de modifier un enfant dans "OA.VST_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.CAMP_OA" doit exister à la création d'un enfant dans "OA.VST_OA"
	if :new.CAMP_OA__ID_CAMP is not null and seq = 0 then 
		open c2_vst_oa ( :new.CAMP_OA__ID_CAMP);
		fetch c2_vst_oa into dummy;
		found := c2_vst_oa%FOUND;
		close c2_vst_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.CAMP_OA". Impossible de modifier un enfant dans "OA.VST_OA".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OA.INSPECTEUR_OA" doit exister à la création d'un enfant dans "OA.VST_OA"
	if :new.INSPECTEUR_OA__NOM is not null and seq = 0 then 
		open c3_vst_oa ( :new.INSPECTEUR_OA__NOM);
		fetch c3_vst_oa into dummy;
		found := c3_vst_oa%FOUND;
		close c3_vst_oa;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OA.INSPECTEUR_OA". Impossible de modifier un enfant dans "OA.VST_OA".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OA"."TUA_VSTOA" after update
of DSC_OA__NUM_OA,CAMP_OA__ID_CAMP
on OA.VST_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OA.VST_OA" dans les enfants "OA.PHOTO_VST_OA"
	if ((updating('DSC_OA__NUM_OA') and :old.DSC_OA__NUM_OA != :new.DSC_OA__NUM_OA) or 
	(updating('CAMP_OA__ID_CAMP') and :old.CAMP_OA__ID_CAMP != :new.CAMP_OA__ID_CAMP)) then 
		update OA.PHOTO_VST_OA
		set DSC_OA__NUM_OA = :new.DSC_OA__NUM_OA,
		CAMP_OA__ID_CAMP = :new.CAMP_OA__ID_CAMP  
		where DSC_OA__NUM_OA = :old.DSC_OA__NUM_OA and 
		CAMP_OA__ID_CAMP = :old.CAMP_OA__ID_CAMP;
	end if;
	--  Modification du code du parent "OA.VST_OA" dans les enfants "OA.SPRT_VST_OA"
	if ((updating('DSC_OA__NUM_OA') and :old.DSC_OA__NUM_OA != :new.DSC_OA__NUM_OA) or 
	(updating('CAMP_OA__ID_CAMP') and :old.CAMP_OA__ID_CAMP != :new.CAMP_OA__ID_CAMP)) then 
		update OA.SPRT_VST_OA
		set DSC_OA__NUM_OA = :new.DSC_OA__NUM_OA,
		CAMP_OA__ID_CAMP = :new.CAMP_OA__ID_CAMP  
		where DSC_OA__NUM_OA = :old.DSC_OA__NUM_OA and 
		CAMP_OA__ID_CAMP = :old.CAMP_OA__ID_CAMP;
	end if;
	--  Modification du code du parent "OA.VST_OA" dans les enfants "OA.ENTETE_OA"
	if ((updating('DSC_OA__NUM_OA') and :old.DSC_OA__NUM_OA != :new.DSC_OA__NUM_OA) or 
	(updating('CAMP_OA__ID_CAMP') and :old.CAMP_OA__ID_CAMP != :new.CAMP_OA__ID_CAMP)) then 
		update OA.ENTETE_OA
		set DSC_OA__NUM_OA = :new.DSC_OA__NUM_OA,
		CAMP_OA__ID_CAMP = :new.CAMP_OA__ID_CAMP  
		where DSC_OA__NUM_OA = :old.DSC_OA__NUM_OA and 
		CAMP_OA__ID_CAMP = :old.CAMP_OA__ID_CAMP;
	end if;
	--  Modification du code du parent "OA.VST_OA" dans les enfants "OA.CD_PRECO__SPRT_VST_OA"
	if ((updating('DSC_OA__NUM_OA') and :old.DSC_OA__NUM_OA != :new.DSC_OA__NUM_OA) or 
	(updating('CAMP_OA__ID_CAMP') and :old.CAMP_OA__ID_CAMP != :new.CAMP_OA__ID_CAMP)) then 
		update OA.CD_PRECO__SPRT_VST_OA
		set DSC_OA__NUM_OA = :new.DSC_OA__NUM_OA,
		CAMP_OA__ID_CAMP = :new.CAMP_OA__ID_CAMP  
		where DSC_OA__NUM_OA = :old.DSC_OA__NUM_OA and 
		CAMP_OA__ID_CAMP = :old.CAMP_OA__ID_CAMP;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OA"."TDA_VSTOA" after delete
on OA.VST_OA for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OA.PHOTO_VST_OA"
	delete OA.PHOTO_VST_OA
	where DSC_OA__NUM_OA = :old.DSC_OA__NUM_OA and 
	CAMP_OA__ID_CAMP = :old.CAMP_OA__ID_CAMP;
	
	--  Suppression des enfants dans "OA.SPRT_VST_OA"
	delete OA.SPRT_VST_OA
	where DSC_OA__NUM_OA = :old.DSC_OA__NUM_OA and 
	CAMP_OA__ID_CAMP = :old.CAMP_OA__ID_CAMP;
	
	--  Suppression des enfants dans "OA.ENTETE_OA"
	delete OA.ENTETE_OA
	where DSC_OA__NUM_OA = :old.DSC_OA__NUM_OA and 
	CAMP_OA__ID_CAMP = :old.CAMP_OA__ID_CAMP;
	
	--  Suppression des enfants dans "OA.CD_PRECO__SPRT_VST_OA"
	delete OA.CD_PRECO__SPRT_VST_OA
	where DSC_OA__NUM_OA = :old.DSC_OA__NUM_OA and 
	CAMP_OA__ID_CAMP = :old.CAMP_OA__ID_CAMP;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


