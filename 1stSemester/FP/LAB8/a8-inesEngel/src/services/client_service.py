from dataclasses import dataclass
from src.domain.client_entity import Client
from src.repository.client_repo import ClientRepo
from src.Validators.validators import Validators
from src.Validators.functions import custom_filter
from src.Validators.errors import *
@dataclass(frozen=True)
class ClientService:
    clientRepo:ClientRepo
    def add_client(self, client_id, name):
        client_id=int(client_id)
        client=Client(client_id,name)
        self.clientRepo.save(client)

    def list_clients(self):
        return self.clientRepo.list_clients()

    def remove_client(self, client_id):
        client_id=int(client_id)
        client=self.clientRepo.get_client_by_id(client_id)
        self.clientRepo.remove(client)

    def update_client_by_id(self, client_id, name):
        client_id=int(client_id)
        client=self.clientRepo.get_client_by_id(client_id)
        self.clientRepo.update_client_by_id(client,name)

    def search_by_id(self, did):
        did=str(did)
        if not self._validator.validate_id(did):
            raise IdError

        def fil(client):
            if did in str(client.client_id):
                return True
            return False
        return custom_filter(self.clientRepo.list_clients(),ok=fil())

    def search_by_name(self, name):
        if not self._validator.validate_name(name):
            raise NameError

        name=name.lower()

        def fil(client):
            if name in client.name.lower():
                return True
            return False

        return custom_filter(self.clientRepo.list_clients(), ok=fil())

    
