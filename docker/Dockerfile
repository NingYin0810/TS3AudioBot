FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine
#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine-arm64v8
#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine-arm32v7

# which version and flavour of the audiobot to use
ARG TS3_AUDIOBOT_RELEASE="0.12.0"
ARG TS3_AUDIOBOT_FLAVOUR="TS3AudioBot_dotnetcore3.1.zip"


# install all pre-requisites, these will be needed always
RUN apk add \
    opus-dev \
    yt-dlp \
    youtube-dl \
    ffmpeg

# download and install the TS3AudioBot in the specified version and flavour
RUN mkdir -p /app \
    && cd /app \
    && echo "downloading https://github.com/Splamy/TS3AudioBot/releases/download/${TS3_AUDIOBOT_RELEASE}/${TS3_AUDIOBOT_FLAVOUR}" \
    && wget https://github.com/Splamy/TS3AudioBot/releases/download/${TS3_AUDIOBOT_RELEASE}/${TS3_AUDIOBOT_FLAVOUR} -O TS3AudioBot.zip \
    && unzip TS3AudioBot.zip \
    && rm TS3AudioBot.zip

# make data directory and chown it to the ts3bot user
RUN mkdir -p /app/data

# set the work dir to data, so users can properly mount their config files to this dir with -v /host/path/to/data:/data
WORKDIR /app/data

# expose the webserver port
EXPOSE 58913

CMD ["dotnet", "/app/TS3AudioBot.dll", "--non-interactive"]
