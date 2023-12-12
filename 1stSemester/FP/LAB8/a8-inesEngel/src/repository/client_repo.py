#from dataclasses import dataclass, field
from src.domain.client_entity import Client


#@dataclass(frozen=True)
class ClientRepo:
    def __init__(self):
        self.__clients=[]
   # clients: list[Client] = field(default_factory=list)

    def list_clients(self):
        return self.__clients

    def save(self, client):
        self.__clients.append(client)

    def remove(self, client):
        self.__clients.remove(client)

    def get_client_by_id(self, id):
        for client in self.__clients:
            if client.client_id == id:
                return client
        return None

    def update_client_by_id(self, client, name):
        #index = self._clients.index(client)
        count=0
        index=0
        for client in self.__clients:
            count=count+1
            if client.client_id == id:
                index=count
        client.name = name
        self.__clients[index] = client

    def search(self,method):
        found=""
        for client in self.__clients:
            id=client.client_id
            name=client.name
            method=method.lower()
            if method in name.lower():
                found=found+" "+str(id)+" "+str(name)

        if found=="":
            found="Unfound search"

        return found

    def topClients(self):
        clientlist=self.__clients
        rentDict=self._client_rents
        for i in range(0, len(clientlist)):
            for j in range(i+1, len(clientlist)):
                if int(rentDict[str(clientlist[i].client_id)])< int(rentDict[str(clientlist[j].client_id)]):
                    clientlist[i],clientlist[j]=clientlist[j],clientlist[i]
        top=""
        for client in clientlist:
            top=top+" "+str(client.client_id+" "+str(client.name))
        return top

# if __name__=="__main__":
#     repo=ClientRepo()
#     client=Client(1,"inesina")
#     repo.save(client)
#     print(repo.clients)
