using Microsoft.AspNetCore.Http;
using Ocelot.Middleware;
using Ocelot.Multiplexer;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiGateways
{
    public class MyDefinedAggregator : IDefinedAggregator
    {
        public async Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
        {
            var bufferWriter = new ArrayBufferWriter<byte>();

            await using (var writer=new Utf8JsonWriter(bufferWriter))
            {
                writer.WriteEndObject();

                var content = new ByteArrayContent(bufferWriter.WrittenSpan.ToArray())
                {
                    Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
                };
                return new DownstreamResponse(new HttpResponseMessage());
            }
        }
    }
}
