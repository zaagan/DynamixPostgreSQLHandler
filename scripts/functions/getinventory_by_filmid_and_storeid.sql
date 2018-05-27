CREATE OR REPLACE FUNCTION getinventory_by_filmid_and_storeid(
	p_film_id integer,
	p_store_id integer
	)
    RETURNS SETOF inventory
    LANGUAGE 'plpgsql'
AS $BODY$
BEGIN
    RETURN QUERY (select * from inventory WHERE film_id = p_film_id AND store_id = p_store_id);
END
$BODY$;