using ApiWebNetCore.Context;
using ApiWebNetCore.DTOS;
using ApiWebNetCore.Modelo;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebNetCore.Repositorio
{
    public class CertificadosRepositorio : ICertificadosRepositorio
    {
        private MainContext _contexto;
        private readonly IMapper _mapper;

        public CertificadosRepositorio(MainContext contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;
        }


        public async Task<CertificadoDTO> BuscarCertificadoAsync(int NumeroCertificado)
        {
            var resultadoBBDD = await _contexto.Certificados.FirstOrDefaultAsync(u => u.NumeroCertificado == NumeroCertificado);
            return _mapper.Map<CertificadoDTO>(resultadoBBDD);
        }

        public async Task<List<CertificadoDTO>> ConseguirCertificadosAsync()
        {
            var resultadoBBDD = await _contexto.Certificados.ToListAsync();
            return _mapper.Map<List<CertificadoDTO>>(resultadoBBDD);
        }

        public async Task<Guid> AgregarCertificado(CertificadoDTO certificadoDTO)
        {
            if (_contexto.Certificados.Any(c => c.NumeroCertificado == certificadoDTO.NumeroCertificado))
            {
                return Guid.Empty;
            }
            var certificado = _mapper.Map<Certificado>(certificadoDTO);
            certificado.CertificadoId = Guid.NewGuid();
            _contexto.Add(certificado);
            await _contexto.SaveChangesAsync();
            return certificado.CertificadoId;
        }

    }
}
