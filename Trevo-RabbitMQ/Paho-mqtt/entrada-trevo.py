import paho.mqtt.client as mqtt 
import time

def on_message(client, userdata, message):
    print("message received " ,str(message.payload.decode("utf-8")))
    print("message topic=", message.topic)

#broker = "{Broker IP Address}" 
#username = "{MQTT Client Username}"
#password = "{MQTT Client Password}"

broker = "rabbitmq" #"{Broker IP Address}" 
username = "guest"   #"{MQTT Client Username}"
password = "guest"   #"{MQTT Client Password}"

#subscribe_topic = "/SlHello" # example: "/Platform_A/Instance_1/Object_X/Property_X"

client = mqtt.Client(client_id="")
client.username_pw_set(username, password)
client.on_message=on_message 

client.connect(broker) 
client.loop_start() 

# Subscribe
subscribe_topic = "/SlHello" # example: "/Platform_A/Instance_1/Object_X/Property_X"

client.subscribe(subscribe_topic) 

# Publish
publish_topic = "/SlHello"
payload = "{Hello World!}"
client.publish(publish_topic, payload, retain=True) 

time.sleep(15)
client.loop_stop()
