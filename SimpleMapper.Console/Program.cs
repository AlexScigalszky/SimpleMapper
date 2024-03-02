using Mappear;
using Microsoft.Extensions.DependencyInjection;
using SimpleMapper.Console;




// Configurar el contenedor de servicios y resolver la dependencia
var serviceProvider = new ServiceCollection()
    .AddSimpleMapper()
    .BuildServiceProvider();

serviceProvider.GetService<HelloWord>().ShowMessage(text)