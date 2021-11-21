FROM node:alpine AS build

WORKDIR /src
COPY package*.json ./
RUN npm install
COPY . ./
RUN npm run build
COPY . ./

FROM nginx:alpine
WORKDIR /
COPY --from=build /src/_site /var/www/html 