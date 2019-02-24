CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);


DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190224103209_InitialCreate') THEN
    CREATE SCHEMA IF NOT EXISTS blog;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190224103209_InitialCreate') THEN
    CREATE TABLE blog.author (
        id uuid NOT NULL,
        name text NULL,
        created_at timestamp with time zone NOT NULL,
        updated_at timestamp with time zone NOT NULL,
        CONSTRAINT "PK_author" PRIMARY KEY (id)
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190224103209_InitialCreate') THEN
    CREATE TABLE blog.post (
        id uuid NOT NULL,
        author_id uuid NULL,
        title text NULL,
        content text NULL,
        created_at timestamp with time zone NOT NULL,
        updated_at timestamp with time zone NOT NULL,
        CONSTRAINT "PK_post" PRIMARY KEY (id),
        CONSTRAINT "FK_post_author_author_id" FOREIGN KEY (author_id) REFERENCES blog.author (id) ON DELETE RESTRICT
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190224103209_InitialCreate') THEN
    CREATE TABLE blog.comment (
        id uuid NOT NULL,
        author_id uuid NULL,
        post_id uuid NULL,
        content text NULL,
        created_at timestamp with time zone NOT NULL,
        updated_at timestamp with time zone NOT NULL,
        CONSTRAINT "PK_comment" PRIMARY KEY (id),
        CONSTRAINT "FK_comment_author_author_id" FOREIGN KEY (author_id) REFERENCES blog.author (id) ON DELETE RESTRICT,
        CONSTRAINT "FK_comment_post_post_id" FOREIGN KEY (post_id) REFERENCES blog.post (id) ON DELETE RESTRICT
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190224103209_InitialCreate') THEN
    CREATE UNIQUE INDEX "IX_author_name" ON blog.author (name);
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190224103209_InitialCreate') THEN
    CREATE INDEX "IX_comment_author_id" ON blog.comment (author_id);
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190224103209_InitialCreate') THEN
    CREATE INDEX "IX_comment_post_id" ON blog.comment (post_id);
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190224103209_InitialCreate') THEN
    CREATE INDEX "IX_post_author_id" ON blog.post (author_id);
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190224103209_InitialCreate') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20190224103209_InitialCreate', '2.2.0-rtm-35687');
    END IF;
END $$;
