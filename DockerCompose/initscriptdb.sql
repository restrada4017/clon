CREATE TABLE IF NOT EXISTS public."ADN"
(
    "Id" integer NOT NULL,
    "ADN" character varying(1000) COLLATE pg_catalog."default" NOT NULL,
    "IsClon" boolean NOT NULL,
    CONSTRAINT "ADN_pkey" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."ADN"
    OWNER to postgres;