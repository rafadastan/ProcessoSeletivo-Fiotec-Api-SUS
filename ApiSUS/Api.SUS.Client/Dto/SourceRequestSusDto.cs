using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.SUS.Client.Dto
{
    public class SourceRequestSusDto
    {
        [JsonProperty(PropertyName = "vacina_categoria_codigo")]
        public string VacinaCategoriaCodigo { get; set; }

        [JsonProperty(PropertyName = "data_importacao_datalake")]
        public DateTime DataImportacaoDatalake { get; set; }

        [JsonProperty(PropertyName = "vacina_codigo")]
        public string VacinacaoCodigo { get; set; }

        [JsonProperty(PropertyName = "paciente_endereco_coIbgeMunicipio")]
        public string PacienteEnderecoCodigoIbge { get; set; }

        [JsonProperty(PropertyName = "sistema_origem")]
        public string SistemaOrigem { get; set; }

        [JsonProperty(PropertyName = "estalecimento_noFantasia")]
        public string EstabelecimentoNoFantasia { get; set; }

        [JsonProperty(PropertyName = "vacina_categoria_nome")]
        public string VacinaCategoriaNome { get; set; }

        [JsonProperty(PropertyName = "estabelecimento_municipio_nome")]
        public string EstabelecimentoMunicipioNome { get; set; }

        [JsonProperty(PropertyName = "id_sistema_origem")]
        public string IdSistemaOrigem { get; set; }

        [JsonProperty(PropertyName = "ds_condicao_maternal")]
        public string? DsCondicaoMaternal { get; set; }

        [JsonProperty(PropertyName = "paciente_racaCor_valor")]
        public string PacienteRacaCorValor { get; set; }

        [JsonProperty(PropertyName = "data_importacao_rnds")]
        public DateTime DataImportacaoRnds { get; set; }

        [JsonProperty(PropertyName = "estabelecimento_razaoSocial")]
        public string EstabelecimentoRazaoSocial { get; set; }

        [JsonProperty(PropertyName = "vacina_fabricante_nome")]
        public string VacinacaFabricanteNome { get; set; }

        [JsonProperty(PropertyName = "dt_deleted")]
        public DateTime? DataDelete { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "co_condicao_maternal")]
        public string? CoCondicaoMaternal { get; set; }

        [JsonProperty(PropertyName = "vacina_descricao_dose")]
        public string VacinaDescricaoDose { get; set; }

        [JsonProperty(PropertyName = "estabelecimento_valor")]
        public string EstabelecimentoValor { get; set; }

        [JsonProperty(PropertyName = "@version")]
        public string Version { get; set; }

        [JsonProperty(PropertyName = "estabelecimento_municipio_codigo")]
        public string EstabelecimentoMunicipioCodigo { get; set; }

        [JsonProperty(PropertyName = "paciente_dataNascimento")]
        public DateTime PacienteDataNascimento { get; set; }

        [JsonProperty(PropertyName = "paciente_enumSexoBiologico")]
        public string PacienteEnumSexoBiologico { get; set; }

        [JsonProperty(PropertyName = "paciente_racaCor_codigo")]
        public string PacienteRacaCorCodigo { get; set; }

        [JsonProperty(PropertyName = "vacina_nome")]
        public string VacinaNome { get; set; }

        [JsonProperty(PropertyName = "vacina_numDose")]
        public string VacinaNumDose { get; set; }

        [JsonProperty(PropertyName = "paciente_idade")]
        public int PacienteIdade { get; set; }

        [JsonProperty(PropertyName = "paciente_endereco_cep")]
        public string PacienteEnderecoCep { get; set; }

        [JsonProperty(PropertyName = "paciente_endereco_nmPais")]
        public string PacienteEnderecoNumeroPais { get; set; }

        [JsonProperty(PropertyName = "paciente_endereco_coPais")]
        public string PacienteEnderecoCodigoPais { get; set; }

        [JsonProperty(PropertyName = "@timestamp")]
        public DateTime TimeStamp { get; set; }

        [JsonProperty(PropertyName = "paciente_nacionalidade_enumNacionalidade")]
        public string PacienteNacionalidadeNacionalidade { get; set; }

        [JsonProperty(PropertyName = "vacina_grupoAtendimento_codigo")]
        public string VacinaGrupoAtendimentoCodigo { get; set; }

        [JsonProperty(PropertyName = "document_id")]
        public string DocumentId { get; set; }

        [JsonProperty(PropertyName = "estabelecimento_uf")]
        public string EstabelecimentoUf { get; set; }

        [JsonProperty(PropertyName = "vacina_dataAplicacao")]
        public DateTime DataAplicacao { get; set; }

        [JsonProperty(PropertyName = "vacina_lote")]
        public string VacinaLote { get; set; }

        [JsonProperty(PropertyName = "vacina_grupoAtendimento_nome")]
        public string VacinaGrupoAtendimentoNome { get; set; }

        [JsonProperty(PropertyName = "vacina_fabricante_referencia")]
        public string? VacinaFabricanteReferencia { get; set; }

        [JsonProperty(PropertyName = "paciente_endereco_nmMunicipio")]
        public string PacienteEnderecoNumeroMunicipio { get; set; }

        [JsonProperty(PropertyName = "paciente_endereco_uf")]
        public string PacienteEnderecoUf { get; set; }

        [JsonProperty(PropertyName = "paciente_id")]
        public string PacienteId { get; set; }
    }
}
