import requests

API_URL = "http://localhost:5230/api/pessoa/"

def categorizar_idade(idade):
    if idade < 30:
        return "Jovem"
    elif 30 <= idade <= 40:
        return "Adulto"
    else:
        return "Sênior"

def buscar_pessoa(id):
    response = requests.get(f"{API_URL}{id}")
    
    if response.status_code == 200:
        pessoa = response.json()
        categoria = categorizar_idade(pessoa["idade"])
        print(f"Registro encontrado:\n"
              f"Nome: {pessoa['nome']}\n"
              f"Idade: {pessoa['idade']}\n"
              f"Categoria: {categoria}\n"
              f"Cidade: {pessoa['cidade']}\n"
              f"Profissão: {pessoa['profissao']}\n")
    else:
        print("Registro não encontrado.")

if __name__ == "__main__":
    id_pessoa = int(input("Digite o ID da pessoa: "))
    buscar_pessoa(id_pessoa)
