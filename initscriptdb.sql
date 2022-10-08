CREATE TABLE IF NOT EXISTS public."ADN"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "ADN" character varying(1000) COLLATE pg_catalog."default" NOT NULL,
    "IsClon" boolean NOT NULL,
    CONSTRAINT "ADN_pkey" PRIMARY KEY ("Id")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."ADN"
    OWNER to postgres;