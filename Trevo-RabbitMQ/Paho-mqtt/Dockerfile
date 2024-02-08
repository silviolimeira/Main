FROM python:3

WORKDIR /usr/src/app

COPY requirements.txt ./
RUN pip install --no-cache-dir -r requirements.txt

COPY . .

CMD [ "python", "./entrada-trevo.py" ]


# build -t slhello:1.0 .
# docker run -it --rm --name slhello slhello:1.0


# requeriments-txt
# paho-mqtt==1.6.1
