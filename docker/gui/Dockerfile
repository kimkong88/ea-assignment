#############
#### GUI ####
#############

## GUI Builder ##
FROM node:8 AS assignment-gui-builder

# Install newest npm@6.*
RUN npm install npm@^6.0.0 -g

# Install node modules
WORKDIR /app/gui/
COPY web/gui/package.json web/gui/package-lock.json ./
RUN npm ci

# Build
COPY web/gui ./
RUN npm run-script build-prod

## GUI Runtime Image ##
FROM nginx:stable AS assignment-gui-runtime
WORKDIR /app
COPY --from=assignment-gui-builder /app/gui/dist ./gui
COPY ./docker/nginx/default.conf /etc/nginx/conf.d/default.conf
EXPOSE 80/tcp

