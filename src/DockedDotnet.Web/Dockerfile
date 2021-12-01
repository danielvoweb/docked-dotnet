FROM node:alpine AS build

WORKDIR /src
COPY package*.json ./
RUN npm install && npm cache clean --force
COPY . ./
RUN npm run build
COPY . ./

FROM nginx:alpine
WORKDIR /
COPY --from=build /src/_site /var/www/html 