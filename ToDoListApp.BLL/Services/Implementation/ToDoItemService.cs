using AutoMapper;
using ToDoListApp.DAL.Entities;
using ToDoListApp.BLL.Common;
using ToDoListApp.BLL.DTOs.ToDoItemDtos;
using ToDoListApp.BLL.Services.Abstraction;
using ToDoListApp.DAL.Repositories.UnitOfWorkPattern.Abstraction;

namespace ToDoListApp.BLL.Services.Implementation
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ToDoItemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseResult<List<GetToDoItemDto>>> GetAllToDoItemDtosByCategoryIdAsync(int categoryId)
        {
            try
            {
                var result = await _unitOfWork.ToDoItems.GetAllEntitiesAsync(t => t.CategoryId == categoryId, t => t.Category);
                var mappedResult = _mapper.Map<List<GetToDoItemDto>>(result);
                
                return new ResponseResult<List<GetToDoItemDto>>
                (
                    true,
                    null,
                    mappedResult
                );
            }
            catch(Exception ex)
            {
                return new ResponseResult<List<GetToDoItemDto>>
                (
                    false,
                    ex.Message,
                    null
                );
            }
        }

        public async Task<ResponseResult<GetToDoItemDto>> GetToDoItemDtoByIdAsync(int id)
        {
            try
            {
                var result = await _unitOfWork.ToDoItems.GetEntityByIdAsync(id, t => t.Category);
                var mappedResult = _mapper.Map<GetToDoItemDto>(result);
                
                return new ResponseResult<GetToDoItemDto>
                (
                    true,
                    null,
                    mappedResult
                );
            }
            catch (Exception ex)
            {
                return new ResponseResult<GetToDoItemDto>
                (
                   false,
                   ex.Message,
                   null
                );
            }
        }

        public async Task<ResponseResult<CreateToDoItemDto>> CreateToDoItemDtoAsync(CreateToDoItemDto createToDoItemDto)
        {
            try
            {
                var mappedResult = _mapper.Map<ToDoItem>(createToDoItemDto);
                await _unitOfWork.ToDoItems.AddEntityAsync(mappedResult);
                var changes = await _unitOfWork.SaveChangesAsync();
                
                if(changes > 0)
                {
                    return new ResponseResult<CreateToDoItemDto>
                    (
                        true,
                        null,
                        createToDoItemDto
                    );
                }
                else
                {
                    return new ResponseResult<CreateToDoItemDto>
                    (
                        false,
                        "Failed to create the ToDoItem.",
                        null
                    );
                }
            }
            catch(Exception ex)
            {
                return new ResponseResult<CreateToDoItemDto>
                (
                    false,
                    ex.Message,
                    null
                );
            }
        }

        public async Task<ResponseResult<int>> DeleteToDoItemDtoAsync(int id)
        {
            try
            {
                var result = await _unitOfWork.ToDoItems.GetEntityByIdAsync(id);

                if(result != null)
                {
                    await _unitOfWork.ToDoItems.DeleteEntityAsync(id);
                    var changes = await _unitOfWork.SaveChangesAsync();

                    if(changes > 0)
                    {
                        return new ResponseResult<int>
                        (
                            true,
                            null,
                            id
                        );
                    }
                    else
                    {
                        return new ResponseResult<int>
                        (
                            false,
                            "Failed to delete the ToDoItem.",
                            id
                        );
                    }
                }
                else
                {
                    return new ResponseResult<int>
                    (
                        false,
                        "ToDoItem not found.",
                        id
                    );
                }
            }
            catch(Exception ex)
            {
                return new ResponseResult<int>
                (
                    false,
                    ex.Message,
                    id
                );
            }
        }

        public async Task<ResponseResult<UpdateToDoItemDto>> UpdateToDoItemDtoAsync(UpdateToDoItemDto updateToDoItemDto)
        {
            try
            {
                var result = await _unitOfWork.ToDoItems.GetEntityByIdAsync(updateToDoItemDto.Id);

                if (result != null)
                {
                    var mappedResult = _mapper.Map<ToDoItem>(updateToDoItemDto);
                    _unitOfWork.ToDoItems.UpdateEntity(mappedResult);
                    var changes = await _unitOfWork.SaveChangesAsync();

                    if(changes > 0)
                    {
                        return new ResponseResult<UpdateToDoItemDto>
                        (
                            true,
                            null,
                            updateToDoItemDto
                        );
                    }
                    else
                    {
                        return new ResponseResult<UpdateToDoItemDto>
                        (
                            false,
                            "Failed to update the ToDoItem.",
                            null
                        );
                    }
                }
                else
                {

                    return new ResponseResult<UpdateToDoItemDto>
                    (
                        false,
                        "ToDoItem not found.",
                        null
                    );
                }
            }
            catch(Exception ex ) 
            {
                return new ResponseResult<UpdateToDoItemDto>
                (
                    false,
                    ex.Message,
                    null
                );
            }
        }

        public async Task<ResponseResult<bool>> CheckToDoItemUniqueTitleAsync(string title, int categoryId)
        {
            try
            {
                var result = await _unitOfWork.ToDoItems.AnyAsync(t => t.Title == title && t.CategoryId == categoryId);

                if(!result)
                {
                    return new ResponseResult<bool>
                    (
                        true,
                        null,
                        true
                    );
                }
                else
                {
                    return new ResponseResult<bool>
                    (
                        false,
                        "A ToDoItem with this title already exists in the category.",
                        false
                    );
                }
            }
            catch(Exception ex)
            {
                return new ResponseResult<bool>
                (
                    false,
                    ex.Message,
                    false
                );
            }
        }
    }
}
