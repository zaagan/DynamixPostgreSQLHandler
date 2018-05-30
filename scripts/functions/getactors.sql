CREATE OR REPLACE FUNCTION getactors(
	)
    RETURNS SETOF actor 
    LANGUAGE 'plpgsql'
AS $BODY$
BEGIN
RETURN query execute 'select * from actor;';
END
$BODY$;