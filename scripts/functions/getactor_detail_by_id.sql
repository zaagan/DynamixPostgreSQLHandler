CREATE OR REPLACE FUNCTION getactor_detail_by_id(p_actor_id integer)
      RETURNS SETOF actor LANGUAGE 'plpgsql' AS $BODY$
BEGIN
    RETURN QUERY (SELECT * FROM actor WHERE actor_id = p_actor_id );
END
$BODY$;