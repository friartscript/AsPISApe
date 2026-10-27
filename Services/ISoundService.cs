namespace AsPISApe.Services;

public interface ISoundService
{
	void PlayHover();
	void PlayClick();
	void PlaySelect();
	void PlaySuccess();
	void PlayError();
	void PlayLevelUp();
	void PlayPageTurn();
}
