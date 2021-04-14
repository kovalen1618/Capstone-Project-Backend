using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using playlist_app_backend.Contracts;
using playlist_app_backend.Entities.DataTransferObjects;
using playlist_app_backend.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace playlist_app_backend.Controllers
{
    [Route("api/playlists/{playlistId}/items")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;
        private IMapper _mapper;
        private ILoggerManager _logger;
        private Item item;

        public ItemController(IRepositoryWrapper repoWrapper, IMapper mapper, ILoggerManager logger)
        {
            _repoWrapper = repoWrapper;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetItemsForPlaylist( int playlistId) 
        {
            // go through each itemrepo and build a result dataset from all items 
            try
            {
                var quoteItems = _repoWrapper.QuoteItem.GetQuoteItemsForPlaylist(playlistId);
                _logger.LogInfo($"Returned all Quote Items for playlist Id {playlistId}");

                var itemResult = mapQouteItemToDto(quoteItems);

                return Ok(itemResult);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong  inside GetItemsForPlaylist action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        private List<ItemDto> mapQouteItemToDto(IEnumerable<QuoteItem> items)
        {
             List<ItemDto> itemDtos = new List<ItemDto>();
            foreach (QuoteItem obj in items)
            {
                ItemDto itemDto = new ItemDto();
                itemDto.Id = obj.Id;
                itemDto.PlaylistId = obj.PlaylistId;
                itemDto.Type = "quote";
                QuoteItemDataDto dataDto = new QuoteItemDataDto();
                dataDto.Text = obj.Text;
                dataDto.Font = obj.Font;
                itemDto.Data = dataDto;
                itemDtos.Add(itemDto);


            }
            return itemDtos;
        }


        [HttpGet]
        [Route("{itemId}")]
        public IActionResult GetQuoteItemById(int itemId)
        {
            try
            {
                var quoteitem = _repoWrapper.QuoteItem.GetQuoteItemById(itemId);

                if (quoteitem == null)
                {
                    _logger.LogError($"Quoteitem with id: {itemId}, hasn't been found in db");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned quoteitem with id: {itemId}");
                    //   var lists = _mapper.Map<QuoteItemDto>(playlist);
                    // return Ok(playlistResult);
                    return StatusCode(500, "Internal server error");
                }
            }
            catch (Exception ex) 
            {
                _logger.LogError($"Something went wrong inside GetQuoteItemById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
            
        }

       
    }
}
