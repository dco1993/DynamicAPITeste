using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DynamicAPI.Model;
using System.Collections.Generic;

namespace DynamicAPI.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase {

        [HttpPost]
        public IActionResult PostContent(RequisicaoDataModel _requisicao) {

            dynamic json = JsonConvert.SerializeObject(_requisicao.Conteudo);
            dynamic conteudo = JsonConvert.DeserializeObject<ExpandoObject>(json);

            List<dynamic> retorno = new List<dynamic>();

            if (conteudo.Nome != null)
            {
                retorno.Add(conteudo.Nome);
            }

            if ( conteudo.Id)
            {
                retorno.Add(conteudo.Id);
            }

            /*foreach (var item in conteudo)
            {
                JObject c = new JObject();

                if (item["NomePessoa"] != null)
                {
                    foreach (var i in item)
                        c.Add(i);

                    Arquivar.SalvarPessoa(c);
                }
                else if (item["NomeSetor"] != null)
                {
                    foreach (var i in item)
                        c.Add(i);

                    Arquivar.SalvarSetor(c);
                }
                else if (item["NomeEmpresa"] != null)
                {
                    foreach (var i in item)
                        c.Add(i);

                    Arquivar.SalvarEmpresa(c);
                }
                else
                {
                    return BadRequest(conteudo);
                }
            }*/

            return Ok(retorno);

        }

    }
}
