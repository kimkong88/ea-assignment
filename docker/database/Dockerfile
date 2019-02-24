##################
#### Database ####
##################
FROM postgres:11 AS assignment-database
COPY --from=assignment-api-builder /app/src/Data/migrations.sql /docker-entrypoint-initdb.d/
# To run migrations on an existing volume:
# docker exec -it assignment_db_1 psql -U admin -d assignment_db -f /docker-entrypoint-initdb.d/migrations.sql