from flask import Flask


app = Flask(__name__)


@app.route("/")
def index():
    return "<h3>Hello, world!</h3>"


@app.route("/info")
def info():
    return "<h3>Сайт создан компанией GeekBrains</h3>"

#идет проверка т.е. если код был запущен из этого файла, 
#то условие окажется верным 
#если же запустить из другого файла, то код не запустится
#чтобы злоумыщленники не запускали данный код
#запуск напрямую, а не из вне
if __name__ == "__main__":
    app.run()