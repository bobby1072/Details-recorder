import requests
import json
class PersonLog:
    def __init__(self, name, age):
        self.Name = name
        self.Age = age
    def submit(self):
        self.baseURI = "https://localhost:7165/Detail/SubmitDetails?name="
        queryAge = self.Age.replace("/", "%2F")
        requestURI = str(self.baseURI + self.Name +"&dOB=" + queryAge)
        requests.post(requestURI, verify=False)
class ShowAll:
    def __init__(self):
        responseRecs = requests.get("https://localhost:7165/Detail/ShowDetails", verify=False)
        self.allRecs = json.loads(responseRecs.text)
